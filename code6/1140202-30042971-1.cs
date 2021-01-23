    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Grimager.ImageProcessing
    {
        public class ImageProcessor
        {
            protected int Columns { get; set; }
    
            public ImageProcessor(int columns)
            {
                Columns = columns;
            }
    
            public string[] ProcessTo(string sourceDirectory, string outputFile)
            {
                var reader = new ImageReader(sourceDirectory);
                int idx = 1;
                var cfg = Settings.Get();
                var images = new List<Image>();
                foreach (var original in reader.GetImages())
                {
                    var img = ResizeImage(original, cfg.Width, cfg.Height);
                    using (var graphic = Graphics.FromImage(img))
                    {
                        graphic.FillRectangle(Brushes.White, new Rectangle(0, 0, cfg.LetterBoxSize, cfg.LetterBoxSize));
                        using (var font = new Font("Arial", cfg.LetterBoxSize - 1))
                        {
                            graphic.DrawString(idx.ToString(), font, Brushes.Red, new PointF(0,0));
                        }
                    }
                    images.Add(img);
                    idx++;
                }
    
                var totalImages = images.Count();
                var totalRows = (int) Math.Ceiling(totalImages/(double)Columns);
                var totalWidth = Columns*cfg.Width + ((Columns - 1) * cfg.Spacing);
                var totalHeight = totalRows * cfg.Height + ((totalRows-1) * cfg.Spacing);
                var output = new Bitmap(totalWidth, totalHeight);
                var row = 0;
                using (var graphic = Graphics.FromImage(output))
                {
                    for (var i = 0; i < totalImages; i++)
                    {
                        if (i> 0 && i%Columns == 0)
                            row++;
    
                        var column = i%Columns;
    
                        var x = column*cfg.Width;
                        if (column > 0)
                        {
                            x += cfg.Spacing*column;
                        }
                        var y = row*cfg.Height;
    
                        if (row > 0)
                        {
                            y += cfg.Spacing*row;
                        }
    
                        graphic.DrawImage(images[i], new Rectangle(new Point(x,y), new Size(cfg.Width, cfg.Height)));
                    }
                }
    
                output.Save(outputFile, ImageFormat.Jpeg);
    
                return new string[0];
            }
    
            protected Image ResizeImage(Image image, int width, int height)
            {
                var destRect = new Rectangle(0, 0, width, height);
                var destImage = new Bitmap(width, height);
    
                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
    
                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
    
                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }
    
                return destImage;
            }
        }
    }
