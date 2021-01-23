    private void List_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var gridView = sender as GridView;
    
        if (gridView != null)
        {
            var isAtLeastOneVisible =
                gridView.SelectedItems.OfType<ImageItem>().Any(i => i.Used == Visibility.Visible);
        }
    }
