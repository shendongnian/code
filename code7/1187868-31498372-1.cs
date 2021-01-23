     graphic.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
     Font font = new Font("Courier New", 18,FontStyle.Bold);
     SolidBrush brush = new SolidBrush(Color.Black);
    
     graphic.DrawString(DateTime.Now.ToString("dd/MM/yy"), font, brush,10,10);
