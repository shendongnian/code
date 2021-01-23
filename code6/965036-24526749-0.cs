        //variables to store the offset values
        double relX;
        double relY;
        void scrollViewer1_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ScrollViewer scroll = sender as ScrollViewer;
            //see if the content size is changed
            if (e.ExtentWidthChange != 0 || e.ExtentHeightChange != 0)
            {
                //calculate and set accordingly
                scroll.ScrollToHorizontalOffset(CalculateOffset(e.ExtentWidth, e.ViewportWidth, scroll.ScrollableWidth, relX));
                scroll.ScrollToVerticalOffset(CalculateOffset(e.ExtentHeight, e.ViewportHeight, scroll.ScrollableHeight, relY));
            }
            else
            {
                //store the relative values if normal scroll
                relX = (e.HorizontalOffset + 0.5 * e.ViewportWidth) / e.ExtentWidth;
                relY = (e.VerticalOffset + 0.5 * e.ViewportHeight) / e.ExtentHeight;
            }
        }
        private static double CalculateOffset(double extent, double viewPort, double scrollWidth, double relBefore)
        {
            //calculate the new offset
            double offset = relBefore * extent - 0.5 * viewPort;
            //see if it is negative because of initial values
            if (offset < 0)
            {
                //center the content
                //this can be set to 0 if center by default is not needed
                offset = 0.5 * scrollWidth;
            }
            return offset;
        }
