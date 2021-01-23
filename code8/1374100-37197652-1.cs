    bool runnning = false
    private async void scroller_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
    {
        if(running)
            return;
        runnning = true;
        try
        {
            if (isLoadingMore)
                return;
            if (scroller.VerticalOffset > scrollContent.ActualHeight - (Frame.ActualHeight + 300))
                await LoadMoreItems();
        }
        finally{ running = false; }
    }
