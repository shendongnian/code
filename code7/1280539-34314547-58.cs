    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ListBox lb = sender as ListBox;
        MainViewModel vm = DataContext as MainViewModel;
        vm.SelectedVNodes.Clear();
        foreach (VNode item in lb.SelectedItems)
        {
            vm.SelectedVNodes.Add(item);
        }
    }
