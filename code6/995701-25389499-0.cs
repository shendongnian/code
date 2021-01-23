    private void TS_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            TS.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            ScrollViewer scrollviewer = sender as ScrollViewer;
            if (e.Delta > 0)
            {
                scrollviewer.LineLeft();
            }
            else
            {
                scrollviewer.LineRight();
            }
            e.Handled = true;
     }
