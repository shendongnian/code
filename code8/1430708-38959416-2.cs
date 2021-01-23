    public static readonly DependencyProperty SelectedItemsListProperty = DependencyProperty.Register("SelectedItemsList", typeof(IList<TestModel>), typeof(CustomDataGrid));
    public IList<TestModel> SelectedItemsList
    {
        get { return (IList<TestModel>)GetValue(SelectedItemsListProperty); }
        set { SetValue(SelectedItemsListProperty, value); }
    }
    void CustomDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        SetCurrentValue(SelectedItemsListProperty, SelectedItems.OfType<TestModel>().ToList());
    }
