    protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
    {
        // Save the selected pivot item variable in the page's State dictionary.
        State["SelectedPivotItem"] = _selectedItem;
     
    }
