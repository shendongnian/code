    async private void Button_Click(object sender, RoutedEventArgs e)
    {
        Task<ContentControl> t = AddContentControl();
        ContentControl ctrl = await t;
    
        RenderTargetBitmap bmp = CaptureScreen(ctrl, 5000, 5000);
        Img.Source = bmp;
    }
    /* Add the ContentControl to the Grid, and keep it hidden using neg. Margin */
    private Task<ContentControl> AddContentControl()
    {
        Task<ContentControl> task = Task.Factory.StartNew(() =>
        {
            ContentControl ctrl = null;
            Dispatcher.Invoke(() =>
            {
    
                ctrl = new ContentControl() { Content = "Not shown", Width = 100, Height = 25, Margin = new Thickness(-8888, 53, 0, 0) };
                Grd.Children.Add(ctrl);
            });
    
            return ctrl;
        });
    
        return task;
    }
    /* Important , wont work with Visibility.Collapse or Hidden */
    private static RenderTargetBitmap CaptureScreen(Visual target, double dpiX, double dpiY)
    {
        if (target == null)
        {
            return null;
        }
        Rect bounds = VisualTreeHelper.GetDescendantBounds(target);
        RenderTargetBitmap rtb = new RenderTargetBitmap((int)(bounds.Width * dpiX / 96.0),
                                                        (int)(bounds.Height * dpiY / 96.0),
                                                        dpiX,
                                                        dpiY,
                                                        PixelFormats.Pbgra32);
        DrawingVisual dv = new DrawingVisual();
        using (DrawingContext ctx = dv.RenderOpen())
        {
            VisualBrush vb = new VisualBrush(target);
            ctx.DrawRectangle(vb, null, new Rect(new Point(), bounds.Size));
        }
        rtb.Render(dv);
        return rtb;
    }
