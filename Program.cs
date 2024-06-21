// See https://aka.ms/new-console-template for more information
using SkiaSharp;

Console.WriteLine("Hello, World!");
/*
SkiaSharp.SKBitmap bmp = SkiaSharp.SKBitmap.Decode(@"TheImageFile.jpg");
// Check the bmp value 
if (bmp != null)
{
    Console.WriteLine("Bmp: " + bmp.Info);
}
else { Console.WriteLine("Bmp is null "); }
*/
string imagePath = "TheImageFile.jpg.jpg";

// Ensure the image file exists
if (!File.Exists(imagePath))
{
    Console.WriteLine("Image file not found.");
    return;
}

// Decode the image
using var inputStream = File.OpenRead(imagePath);
using var bitmap = SKBitmap.Decode(inputStream);

if (bitmap == null)
{
    Console.WriteLine("Failed to decode the image.");
    return;
}

// Display some information about the image
Console.WriteLine($"Image width: {bitmap.Width}");
Console.WriteLine($"Image height: {bitmap.Height}");
Console.WriteLine($"Image color type: {bitmap.ColorType}");

// Optional: Manipulate the image (example: save it as another format)
using var image = SKImage.FromBitmap(bitmap);
using var data = image.Encode(SKEncodedImageFormat.Jpeg, 100);
using var outputStream = File.OpenWrite("output.jpg");
data.SaveTo(outputStream);

Console.WriteLine("Image processed and saved as output.jpg");