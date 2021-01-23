    private void IcTodoList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        DetailedView.DataContext = icTodoList.SelectedItem;
        DetailedView.Visibility = System.Windows.Visibility.Visible;  
    }
