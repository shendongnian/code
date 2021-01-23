            var text = this.RefrencePro;
            int charsFitted;
            int linesFilled;
            var cn6 = new Font("Courier New", 6);
            var stringFormat = new StringFormat { Alignment= StringAlignment.Near };
            var pageSize = printDocument1.DefaultPageSettings.PaperSize;
            // How much size do we need?
            var measuredSize = g.MeasureString(
                text, 
                cn6, 
                new SizeF(pageSize.Width - startX, pageSize.Height),
                stringFormat, 
                out charsFitted, 
                out linesFilled);
            // Draw the string based on how much space
            // there is needed in the rectangle
            graphics.DrawString(
                text, 
                cn6, 
                new SolidBrush(Color.Black), 
                new RectangleF(new PointF(startX, startY +Offset), measuredSize),
                stringFormat);
            // offset based on the earlier measurements
            Offset = Offset + (int) measuredSize.Height;
