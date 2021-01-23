    chart1.BackColor = Color.Fuchsia;
    chart1.ChartAreas[0].BackColor = chart1.BackColor;
    Bitmap bmp = new Bitmap( chart1.ClientSize.Width, chart1.ClientSize.Height);
    chart1.AntiAliasing = AntiAliasingStyles.Graphics;
    chart1.DrawToBitmap(bmp, chart1.ClientRectangle);
    bmp.MakeTransparent(chart1.BackColor);
    bmp.Save(yourFileName, ImageFormat.Png);
