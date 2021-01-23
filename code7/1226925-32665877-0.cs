    private void ItemStckPanel(object sender, TappedRoutedEventArgs e)
    {
            var stackPanel = sender as StackPanel;
            var item = stackPanel.DataContext as FsqBasicItem;
            if(item != null)
            {
                MessageDialog dialog = new MessageDialog(item.name);
                dialog.ShowAsync();
            }
    }
