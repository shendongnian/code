    public void UpdateVisual()
    {
        //If glass isn't enabled, ignore.
        var isDark = !SystemParameters.IsGlassEnabled 
               //Gets a registry value. See below.
            || !Glass.UsesColor 
               //Color threshold. See below.   
            || SystemParameters.WindowGlassColor.GetBrightness() < 137; 
        //Manually update the IsDark property.
        foreach (var tab in _tabPanel.Children.OfType<AwareTabItem>())
        {
            tab.IsDark = isDark;
        }
    }
