            Image original = new Bitmap(/* path to your 5x7 image */);
            Image newImage = new Bitmap(241, 301);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.InterpolationMode = InterpolationMode.Bicubic;
                g.DrawImage(original, new Rectangle(0, 0, newImage.Width, newImage.Height));
            }
