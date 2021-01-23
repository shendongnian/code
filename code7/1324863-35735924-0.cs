    private void SystemParameters_StaticPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "WindowGlassColor")
        {
            RibbonTabControl.UpdateVisual();
        }
    }
