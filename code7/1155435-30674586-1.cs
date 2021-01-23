    CEGrid.Width = double.NaN;
    CEGrid.Height = double.NaN;
    CEGrid.UpdateLayout();
            
    RenderTargetBitmap rtb = new RenderTargetBitmap((int)CEGrid.ActualWidth, (int)CEGrid.ActualHeight, 96, 96, PixelFormats.Pbgra32);
    rtb.Render(CEGrid);
            
    PngBitmapEncoder pbe = new PngBitmapEncoder();
    pbe.Frames.Add(BitmapFrame.Create(rtb));
    MemoryStream stream = new MemoryStream();
    pbe.Save(stream);
    System.Drawing.Bitmap image = (System.Drawing.Bitmap)System.Drawing.Image.FromStream(stream);
    CEGrid.Width = tempWidth;
    CEGrid.Height = tempHeight;
