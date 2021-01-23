    private void TrieButton_Click(object sender, RoutedEventArgs e)
    {
        ListViewTemplate c = (ListViewTemplate) Controls["Liste"];
        if (c.Visibility == Visibility.Visible)
           c.Visibility = Visibility.Collapsed;
        else
            c.Visibility = Visibility.Visible;
    }
