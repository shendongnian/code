    if (SystemTray.ProgressIndicator == null)
    {
        var indicator = new ProgressIndicator { IsIndeterminate = true };
        var visibilityBinding = new Binding("ProgressBarIsActive");
        BindingOperations.SetBinding(indicator, ProgressIndicator.IsVisibleProperty, visibilityBinding);        
        SystemTray.SetProgressIndicator(this, indicator);
