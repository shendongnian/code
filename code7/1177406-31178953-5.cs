    //ViewModel
    public ObservableCollection<YourBusinessItem> SelectedObject {get; set;}
    //in codebehind:
    var binder = new SelectedItemsBinder(listview, viewmodel.SelectedItems);
    binder.Bind();
