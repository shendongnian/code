    public static readonly DependencyProperty IsExpandedProperty = 
        DependencyProperty.Register("IsExpanded", typeof(bool), typeof(ExpandPanel), 
            new PropertyMetadata(true, IsExpanded_Changed));
    
    private static void IsExpanded_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        var panel = (ExpandPanel)sender;
        panel.toggleExpander.IsChecked = IsExpanded;
        panel.changeVisualState(false);
    }
