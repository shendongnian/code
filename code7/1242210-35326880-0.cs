    public MemoryStream GenerateCircle(string firstName, string lastName)
        {
            var avatarString = string.Format("{0}{1}", firstName[0], lastName[0]).ToUpper();
            var randomIndex = new Random().Next(0, _BackgroundColours.Count - 1);
            var bgColour = _BackgroundColours[randomIndex];
            var bmp = new Bitmap(192, 192);
            var sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            var font = new Font("Arial", 72, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.Transparent);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            using (Brush b = new SolidBrush(ColorTranslator.FromHtml("#" + bgColour)))
            {
                graphics.FillEllipse(b, new Rectangle(0, 0, 192, 192));
            }
            graphics.DrawString(avatarString, font, new SolidBrush(Color.WhiteSmoke), 95, 100, sf);
            graphics.Flush();
            var ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);
            return ms;
        }
