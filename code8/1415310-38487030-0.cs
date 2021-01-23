    private static Bitmap ResizeBitmap(Bitmap sourceBMP, Int32 widthMultiplier,
    Int32 heightMultiplier)
        {
            var newWidth = sourceBMP.Width * widthMultiplier;
            var newHeight = sourceBMP.Height * heightMultiplier;
            var result = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(sourceBMP, 0, 0, newWidth, newHeight);
            return result;
        }
        static void Main(string[] args)
        {
            var widthM = 2;
            var heightM = 2;
            var image = (Bitmap)Image.FromFile(@"E:\YOUR_IMAGE_HERE.png", true);
            var newImage = ResizeBitmap(image, widthM, heightM);
            for(var i=0; i<image.Width;++i)
                for(var j=0; j<image.Height;++j)
                {
                    var pixelToCopy = image.GetPixel(i, j);
                    for (var k = 0; k < widthM; ++k)
                        for (var l = 0; l < heightM; ++l)
                            newImage.SetPixel(k * image.Width + i,
                                l * image.Height + j,
                                pixelToCopy);
                }
            newImage.Save(@"E:\NEW_BIG_IMAGE_HERE.png", ImageFormat.Png);
        }
    }
