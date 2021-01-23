    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                string filePath = System.IO.Path.GetFullPath(args[0]);
                byte[] originalImage = System.IO.File.ReadAllBytes(filePath);
                byte[] resizedImage = ScaleImageByPercent(originalImage, 50);
                using (Stream imageStream = new MemoryStream(resizedImage))
                {
                    using (Image scaleImage = Image.FromStream(imageStream))
                    {
                        string outputPath = System.IO.Path.GetDirectoryName(filePath);
                    outputPath = System.IO.Path.Combine(outputPath, $"{System.IO.Path.GetFileNameWithoutExtension(filePath)}_resized.jpg");
                    using (FileStream outputFile = System.IO.File.Open(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        scaleImage.Save(outputFile, ImageFormat.Jpeg);
                    }
                }
            }
        }
        public static byte[] ScaleImageByPercent(byte[] imageBuffer, int Percent)
        {
            using (Stream imageStream = new MemoryStream(imageBuffer))
            {
                using (Image scaleImage = Image.FromStream(imageStream))
                {
                    float scalePercent = ((float)Percent / 100);
                    int originalWidth = scaleImage.Width;
                    int originalHeight = scaleImage.Height;
                    int originalXPoint = 0;
                    int originalYPoint = 0;
                    int scaleXPoint = 0;
                    int scaleYPoint = 0;
                    int scaleWidth = (int)(originalWidth * scalePercent);
                    int scaleHeight = (int)(originalHeight * scalePercent);
                    using (Bitmap scaleBitmapImage = new Bitmap(scaleWidth, scaleHeight, PixelFormat.Format24bppRgb))
                    {
                        scaleBitmapImage.SetResolution(scaleImage.HorizontalResolution, scaleImage.VerticalResolution);
                        Graphics graphicImage = Graphics.FromImage(scaleBitmapImage);
                        graphicImage.CompositingMode = CompositingMode.SourceCopy;
                        graphicImage.InterpolationMode = InterpolationMode.NearestNeighbor;
                        graphicImage.DrawImage(scaleImage,
                            new Rectangle(scaleXPoint, scaleYPoint, scaleWidth, scaleHeight),
                            new Rectangle(originalXPoint, originalYPoint, originalWidth, originalHeight),
                            GraphicsUnit.Pixel);
                        graphicImage.Dispose();
                        ImageConverter converter = new ImageConverter();
                        return (byte[])converter.ConvertTo(scaleBitmapImage, typeof(byte[]));
                    }
                }
            }
        }
    }
    }
