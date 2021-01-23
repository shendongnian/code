    private void Zoom_ViewChangeStarted(object sender, SemanticZoomViewChangedEventArgs e)
    {
        if (!e.IsSourceZoomedInView)
        {
            e.DestinationItem.Item = _selectedHubSection;
        }
    }
