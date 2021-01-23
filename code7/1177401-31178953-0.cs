    //ViewModel
    public ICollectionView BusinessCollection {get; set;}
    public List<YourBusinessItem> SelectedObject {get; set;}
    
    //Codebehind
    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var viewmodel = (ViewModel) DataContext;
        viewmodel.SelectedItems = listview.SelectedItems
            .Cast<YourBusinessItem>()
            .ToList();
    }
