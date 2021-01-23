    Size s = chart1.Size;
    chart1.Hide();
    // pick your size in pixels
    // I simply multiply my screen size..:
    chart1.Size = new System.Drawing.Size(s.Width * 5, s.Height * 5);
    using (Bitmap bmp = new Bitmap(chart1.ClientSize.Width, chart1.ClientSize.Height))
    {
        // you should set the resolution, 
        // although I didn't find a way for iTextSharp to use it visually
        bmp.SetResolution(600, 600);
        using (Graphics G = Graphics.FromImage(bmp))
        {
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            chart1.DrawToBitmap(bmp, chart1.ClientRectangle);
            bmp.Save(yourImageFile, ImageFormat.Png);
        }
    }
    chart1.Size = s;
    chart1.Show();
