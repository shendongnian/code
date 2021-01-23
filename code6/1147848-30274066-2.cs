    using (Bitmap bmp = new Bitmap(chart1.ClientSize.Width, chart1.ClientSize.Height))
    {
        chart1.DrawToBitmap(bmp, chart1.ClientRectangle);
        bmp.Save("yourfilename", ImageFormat.Png);
    }
