    void OnManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
    {
        _panAreaTransform = PanArea.RenderTransform as CompositeTransform;
        _paneRootTransform = PaneRoot.RenderTransform as CompositeTransform;
        if (_panAreaTransform == null || _paneRootTransform == null)
        {
            throw new ArgumentException("Make sure you have copied the default style to Generic.xaml!!");
        }
    }
    void OnManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
    {
        var x = _panAreaTransform.TranslateX + e.Delta.Translation.X;
        // keep the pan within the bountry
        if (x < PanAreaInitialTranslateX || x > 0) return;
        // while we are panning the PanArea on X axis, let's sync the PaneRoot's position X too
        _paneRootTransform.TranslateX = _panAreaTransform.TranslateX = x;
    }
    void OnManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
    {
        var x = e.Velocities.Linear.X;
        // ignore a little bit velocity (+/-0.1)
        if (x <= -0.1)
        {
            CloseSwipeablePane();
        }
        else if (x > -0.1 && x < 0.1)
        {
            if (Math.Abs(_panAreaTransform.TranslateX) > Math.Abs(PanAreaInitialTranslateX) / 2)
            {
                CloseSwipeablePane();
            }
            else
            {
                OpenSwipeablePane();
            }
        }
        else
        {
            OpenSwipeablePane();
        }
    }
