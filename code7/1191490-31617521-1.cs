    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
         // Restore the selected pivot item variable from the page's State dictionary.
         _selectedItem = (int)State["SelectedPivotItem"]
    }
