    private void CreateSaveBitmap(Canvas canvas, string filename, string sensor)
    {
        if(File.Exists(@".\Print\" + sensor + ".jpg"))
        {
             File.Delete(@".\Print\" + sensor + ".jpg");
        }
        int width = (int)(SystemParameters.PrimaryScreenWidth * 0.75);
        int height = (int)canvas.Height;
    
        RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
             width, (int)canvas.Height,
             96d, 96d, PixelFormats.Pbgra32);
        // needed otherwise the image output is black
        canvas.Measure(new System.Windows.Size(width, height));
        canvas.Arrange(new Rect(new System.Windows.Size(width, height)));
    
        renderBitmap.Render(canvas);
    
        //JpegBitmapEncoder encoder = new JpegBitmapEncoder();
        PngBitmapEncoder encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
    
        using (FileStream file = File.Create(filename))
        {
            encoder.Save(file);
            file.Close();
        }
    
        string head = SetHeadForPrintImage(sensor);
        Bitmap bmp = new Bitmap(filename);
        Graphics g = Graphics.FromImage(bmp);
    
        g.DrawString(head, new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular), System.Drawing.Brushes.Black, new PointF(200, 0));
    
        bmp.SetResolution(300, 300);
        bmp.Save(@".\Print\" + sensor + ".jpg");
        bmp.Dispose();
        File.Delete(filename);
    }
