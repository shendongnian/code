    if (list.ItemsSource == null)
    {
        CenterProgressRing.IsActive = false;
        return;
    }
    CenterProgressRing.IsActive = ((IncrementalSource)this.list.ItemsSource).isLoading;
