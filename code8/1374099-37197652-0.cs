    private async void scroller_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
    {
        scroller.Enabled = false;
        try
        {
            if (isLoadingMore)
                return;
            if (scroller.VerticalOffset > scrollContent.ActualHeight - (Frame.ActualHeight + 300))
                await LoadMoreItems();
        }
        finally{ scroller.Enabled = true; }
    }
