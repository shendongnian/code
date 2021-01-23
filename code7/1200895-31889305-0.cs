    var imagePath = textBox1.Text;
    using (var newImage = new Bitmap(640, 640))
    {
        using (var graphics = Graphics.FromImage(newImage))
        {
            graphics.Clear(Color.White);
            using (var image = new Bitmap(imagePath))
            {
                var s = Math.Max(image.Width, image.Height);
                var w = 640 * image.Width / s;
                var h = 640 * image.Height / s;
                var x = (640 - w) / 2;
                var y = (640 - h) / 2;
                graphics.CompositingMode = CompositingMode.SourceOver;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, x, y, w, h);
            }
        }
        newImage.Save(...);
    }
