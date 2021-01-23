    //  This is faintly sketchy, in many people's view, because in principle 
    //  a view can have any type of viewmodel that has properties of the 
    //  appropriate names and types. You *could* make many viewmodels all 
    //  implement some interface that supports common stuff, and make this that
    //  type. That wouldn't save you from the MVVM Inquisition, but it would be
    //  more flexible than this. 
    protected ProjectViewModel ViewModel { get { return DataContext as ProjectViewModel; } }
    public void listBoxProject_MouseDoubleClick(object sender,MouseButtonEventArgs e)
    {
        //  WARNING you need to add range checking here
        var lb = sender as ListBox;
        var item = lb.Items[lb.SelectedIndex];
        ViewModel.ActivateItem(item);
    }
