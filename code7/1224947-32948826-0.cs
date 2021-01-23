    private void OnPresenterSizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (null != _itemsCanvas && null != _presenter && IsExpanded)
        {
            _itemsCanvas.Height = _presenter.DesiredSize.Height;
        }
    }
