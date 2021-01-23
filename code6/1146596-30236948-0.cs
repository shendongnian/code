    var bmp = Bitmap.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\Chrysanthemum.jpg");
    
    using (var gr = Graphics.FromImage(bmp))
    {
        gr.FillRectangle(Brushes.Black, 50, 50, 200, 200);
    }
