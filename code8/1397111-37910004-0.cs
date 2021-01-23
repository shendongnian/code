    chart.Hide();
    Size oldsz = chart.ClientSize;
    Bitmap bmp = new Bitmap(oldsz.Width * 10, oldsz.Height * 10);  // pick your factor    
    chart.ClientSize = new Size(bmp .Width , bmp.Height);
    chart.DrawToBitmap(bmp, chart.ClientRectangle);
    bmp.SetResolution(300, 300);                     // pick your resolution
    bmp.Save("D:\\xBigChart.png", ImageFormat.Png);  // png for crispiness
    chart.ClientSize = oldsz;
    chart.Show();
