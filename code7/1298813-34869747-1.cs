    private void TrieButton_Click(object sender, RoutedEventArgs e)
    {
        ListViewTemplate c = MGrid.FindName("c") as ListViewTemplate;
        if (c.Visibility == Visibility.Visible)
        {
            c.Visibility = Visibility.Collapsed;
        }
        else
        {
            c.Visibility = Visibility.Visible;
        }
    }
