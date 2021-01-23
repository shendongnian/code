        private double offset;
        private void BarScroll(object sender, ScrollViewerViewChangedEventArgs e)
        {
            double newOffset = (sender as ScrollViewer).VerticalOffset;
            if ( newOffset > offset )
            {
                //Logic for scroll down
            }
            else if ( newOffset < offset )
            {
                //Logic for scroll up
            }
            offset = newOffset;
        }
