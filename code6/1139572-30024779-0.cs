    private void OnDraw(CanvasControl sender, CanvasDrawEventArgs args)
    {
        if (imageLoaded)
        {
            using (var session = args.DrawingSession)
            {
                session.Units = CanvasUnits.Pixels;
    
                double displayScaling = DisplayInformation.GetForCurrentView().LogicalDpi / 96.0;
    
                double pixelWidth = sender.ActualWidth * displayScaling;
    
                var scalefactor = pixelWidth / image.Size.Width;
    
                scaleEffect.Source = this.image;
                scaleEffect.Scale = new Vector2()
                {
                    X = (float)scalefactor,
                    Y = (float)scalefactor
                };
    
                blurEffect.Source = scaleEffect;
                blurEffect.BlurAmount = Blur;
    
                session.DrawImage(blurEffect, 0.0f, 0.0f);
            }
        }
    }
