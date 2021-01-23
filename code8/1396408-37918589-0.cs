    private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var ee = new AutoSuggestBoxQuerySubmittedEventArgs();
        AutoSuggestBox_QuerySubmitted(autoSuggestBox, ee);
    }
    
    private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
    {
        if (args.QueryText != null)
        {
        }
    }
