    void Canvas_CreateResources(CanvasControl sender, CanvasCreateResourcesEventArgs args)
    {
        args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
    }
    
    async Task CreateResourcesAsync(CanvasControl sender)
    {
        // here I simply create the bitmap based on an existing image file,
        // check the LoadAsync overload methods, you can also create one from
        // an IRandomAccessStream
        _bitmap = await CanvasBitmap.LoadAsync(sender, "Assets/Food.jpg");
    }
    
    void Canvas_Draw(CanvasControl sender, CanvasDrawEventArgs args)
    {
        using (var session = args.DrawingSession)
        {
            var blur = new GaussianBlurEffect
            {
                BlurAmount = 100.0f, // increase this to make it more blurry or vise versa.
                //Optimization = EffectOptimization.Balanced, // default value
                //BorderMode = EffectBorderMode.Soft // default value
                Source = _bitmap
            };
    
            session.DrawImage(blur, new Rect(0, 0, sender.ActualWidth, sender.ActualHeight),
                new Rect(0, 0, _bitmap.SizeInPixels.Width, _bitmap.SizeInPixels.Height), 0.9f);
        }
    }
    
    void Overlay_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
    {
        // reset the inital with of the Rect
        _x = (float)this.ImagePanel2.ActualWidth;
    }
    
    void Overlay_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
    {
        // get the movement on X axis
        _x += (float)e.Delta.Translation.X;
    
        // keep the pan within the bountry
        if (_x > this.ImagePanel2.ActualWidth || _x < 0) return;
    
        // we clip the overlay to reveal the actual image underneath
        this.Clip.Rect = new Rect(0, 0, _x, this.ImagePanel2.ActualHeight);
    }
    
    void Overlay_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
    {
        // reset the clip to show the full overlay
        this.Clip.Rect = new Rect(0, 0, this.ImagePanel2.ActualWidth, this.ImagePanel2.ActualHeight);
    }
