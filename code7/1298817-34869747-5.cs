    private void TrieButton_Click(object sender, RoutedEventArgs e)
    {
        ListViewTemplate c = MGrid.FindName("c") as ListViewTemplate;
        c.Visibility = c.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
    }
