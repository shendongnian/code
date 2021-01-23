    private void scrollViewer_Loaded(object sender, RoutedEventArgs e)
    {
        timer.Tick += (ss, ee) =>
        {
            if (timer.Interval.Ticks == 300)
            {
                //each time set the offset to scrollviewer.HorizontalOffset + 5
                scrollviewer.ScrollToHorizontalOffset(scrollviewer.HorizontalOffset + 5);
                //if the scrollviewer scrolls to the end, scroll it back to the start.
                if (scrollviewer.HorizontalOffset == scrollviewer.ScrollableWidth)
                    scrollviewer.ScrollToHorizontalOffset(0);
            }
        };
        timer.Interval = new TimeSpan(300);
        timer.Start();
    }
    
    private void scrollviewer_Unloaded(object sender, RoutedEventArgs e)
    {
        timer.Stop();
    }
