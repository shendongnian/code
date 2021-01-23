    private void ScrollItems()
            {
               ScrollToPositionTop(0,0); // It does not scroll to top
            }
    
     private void ScrollToPositionTop(double x, double y)
            {
    
                DoubleAnimation vertAnim = new DoubleAnimation();
                vertAnim.From = mainViewer.VerticalOffset;
                vertAnim.To = y;
                vertAnim.DecelerationRatio = .2;
                vertAnim.Duration = new Duration(TimeSpan.FromMilliseconds(0));
                DoubleAnimation horzAnim = new DoubleAnimation();
                horzAnim.From = mainViewer.HorizontalOffset;
                horzAnim.To = x;
                horzAnim.DecelerationRatio = .2;
                horzAnim.Duration = new Duration(TimeSpan.FromMilliseconds(0));
    
                sb.Children.Add(vertAnim);
                sb.Children.Add(horzAnim);
                Storyboard.SetTarget(vertAnim, mainViewer);
                Storyboard.SetTargetProperty(vertAnim, new PropertyPath(AniScrollViewer.CurrentVerticalOffsetProperty));
                Storyboard.SetTarget(horzAnim, mainViewer);
                Storyboard.SetTargetProperty(horzAnim, new PropertyPath(AniScrollViewer.CurrentHorizontalOffsetProperty));
                sb.Begin(this);
    
            }
