    var sourcePath = textBox1.Text;
    var destinationSize = 640;
    using (var destinationImage = new Bitmap(destinationSize, destinationSize))
    {
        using (var graphics = Graphics.FromImage(destinationImage))
        {
            graphics.Clear(Color.White);
            using (var sourceImage = new Bitmap(sourcePath))
            {
                var s = Math.Max(sourceImage.Width, sourceImage.Height);
                var w = destinationSize * sourceImage.Width / s;
                var h = destinationSize * sourceImage.Height / s;
                var x = (destinationSize - w) / 2;
                var y = (destinationSize - h) / 2;
                // Use alpha blending in case the source image has transparencies.
                graphics.CompositingMode = CompositingMode.SourceOver;
                // Use high quality compositing and interpolation.
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(sourceImage, x, y, w, h);
            }
        }
        destinationImage.Save(...);
    }
