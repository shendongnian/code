    public static void CreateSaveBitmap(Canvas canvas1, Canvas canvas2, string filename)
    {
        RenderTargetBitmap renderBitmap1 = new RenderTargetBitmap((int)canvas1.ActualWidth, (int)canvas1.ActualWidth, 96d, 96d, PixelFormats.Pbgra32);
        canvas1.Measure(new Size((int)canvas1.ActualWidth, (int)canvas1.ActualWidth));
        canvas1.Arrange(new Rect(new Size((int)canvas1.ActualWidth, (int)canvas1.ActualWidth)));
        renderBitmap1.Render(canvas1);
        RenderTargetBitmap renderBitmap2 = new RenderTargetBitmap((int)canvas2.ActualWidth, (int)canvas2.ActualWidth, 96d, 96d, PixelFormats.Pbgra32);
        canvas2.Measure(new Size((int)canvas2.ActualWidth, (int)canvas2.ActualWidth));
        canvas2.Arrange(new Rect(new Size((int)canvas2.ActualWidth, (int)canvas2.ActualWidth)));
        renderBitmap2.Render(canvas2);
        //Combine the images here
        var dg = new DrawingGroup();
        var id1 = new ImageDrawing(renderBitmap1, 
                                   new Rect(0,0,renderBitmap1.Width, renderBitmap1.Height));
        var id2 = new ImageDrawing(renderBitmap2,
                                   new Rect(renderBitmap1.Width, 0
                                            renderBitmap2.Width,
                                            renderBitmap2.Height));
        dg.Children.Add(id1);
        dg.Children.Add(id2);
        var combinedImg = new RenderTargetBitmap((int)(renderBitmap1.Width + renderBitmap2.Width + 0.5),
                              (int)(Math.Max(renderBitmap1.Height, renderBitmap2.Height) + 0.5), 96, 96, PixelFormats.Pbgra32); 
        var dv = new DrawingVisual();
        using(var dc = dv.RenderOpen()){
           dc.DrawDrawing(dg);
        }
        combinedImg.Render(dv);
        //JpegBitmapEncoder encoder = new JpegBitmapEncoder();
        PngBitmapEncoder encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(combinedImg));
        using (FileStream file = File.Create(filename)) {
            encoder.Save(file);
        }
    }
