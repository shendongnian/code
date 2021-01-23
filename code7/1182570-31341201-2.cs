        public static void SetImage(this Control ctrl, Image img)
        {
            var cs = ctrl.Size;
            if (img.Size != cs)
            {
                float ratio = Math.Max(cs.Height / (float)img.Height, cs.Width / (float)img.Width);
                if (ratio > 1)
                {
                    Func<float, int> calc = f => (int)Math.Ceiling(f * ratio);
                    img = new Bitmap(img, calc(img.Width), calc(img.Height));                    
                }
                var part = new Bitmap(cs.Width, cs.Height);
                using (var g = Graphics.FromImage(part))
                {
                    g.DrawImageUnscaled(img, (cs.Width - img.Width) /2, (cs.Height - img.Height) / 2);
                }                
                img = part;
            }
            ctrl.BackgroundImageLayout = ImageLayout.Center;
            ctrl.BackgroundImage = img;
        }
