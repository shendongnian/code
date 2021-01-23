    private void Button_Click(object sender, RoutedEventArgs e)
    {
        SafeMove(2, 1);
    }
    private void SafeMove(int old_index, int new_index)
    {
         var saved_item = _vm.UngroupedItems[old_index];           
        _vm.UngroupedItems.RemoveAt(old_index);
        _vm.UngroupedItems.Insert(new_index, saved_item);
    }
