            public static Image Overlap(Image source1, Image source2)
        {
            var target = new Bitmap(source1.Width, source1.Height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(target);
            graphics.CompositingMode = CompositingMode.SourceOver; // this is the default, but just to be clear
            graphics.DrawImage(source1, 0, 0);
            graphics.DrawImage(source2, 0, 0);
            return target;
        }
