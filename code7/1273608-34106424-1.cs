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
