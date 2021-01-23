    void Img_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
    {
        // dim the image while panning
        this.Img.Opacity = 0.4;
    }
    
    void Img_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
    {
        this.Transform.TranslateX += e.Delta.Translation.X;
        this.Transform.TranslateY += e.Delta.Translation.Y;
    }
    
    void Img_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
    {
        // reset the Opacity
        this.Img.Opacity = 1;
    }
