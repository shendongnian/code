    private void ScrollViewer_OnScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        var sv = sender as ScrollViewer;
        if (sv != null && !_addingData)
        {
            if (sv.ScrollableHeight - e.VerticalOffset == 0)
            {
                _addingData = true;
                GetNewData();
                _addingData = false;
             }
         }
    } 
        private void UIElement_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
