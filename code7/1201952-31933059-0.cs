    private void AppBarToggleButton_Checked(object sender, RoutedEventArgs e)
    {
        // Almost (but not quite) to the top of the page
        SlideVertical(MainGrid,-1 * ActualHeight + 100);
    }
    private void AppBarToggleButton_Unchecked(object sender, RoutedEventArgs e)
    {
        SlideVertical(MainGrid,0);
    }
    private void SlideVertical(UIElement target, double endPos)
    {
        Storyboard sb = new Storyboard();
        DoubleAnimation da = new DoubleAnimation();
        // Over how long to perform the animation. 
        Duration dur = TimeSpan.FromMilliseconds(100);
        da.Duration = dur;
        sb.Duration = dur;
        // From current location to endPos
        var ct = target.RenderTransform as CompositeTransform;
        if (ct == null)
        {
            // Give up if we had some other type of transform
            if (target.RenderTransform != null)
                return;
            // That way we don't step on a non-CompositeTransform
            // RenderTransform if one already exists.
            // That would be bad.
            ct = new CompositeTransform();
            target.RenderTransform = ct;
        }
        double startPos = ct.TranslateY;
        da.From = startPos;
        da.To = endPos;
        sb.Children.Add(da);
        // Choose the element to slide
        Storyboard.SetTarget(da, target);
        // Animate the target's CompositeTransform.TranslateY
        Storyboard.SetTargetProperty(da, "(UIElement.RenderTransform).(CompositeTransform.TranslateY)");
        sb.Begin();
    }
