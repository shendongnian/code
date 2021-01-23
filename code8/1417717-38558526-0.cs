    public ICollectionView FilteredData { get; set; }
    
    private void ComboBoxA_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var z = new CollectionViewSource {Source = ViewModel.ChargedAccounts.Where(p => p != ViewModel.SelectedAccount) };
        FilteredData = z.View;
    }
