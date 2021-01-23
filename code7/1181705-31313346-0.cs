    public void ContainerSelected(object sender, RoutedEventArgs e) {
        EditableControlContainer ecc = (EditableControlContainer)sender;
        ItemContainerGenerator generator = grdArrears.ItemContainerGenerator;
        foreach (var item in grdArrears.Items) {
            var itemContainer = generator.ContainerFromItem(item);
            // Do stuff with the item container (it'll probably be a ListViewItem)
        }
    }
