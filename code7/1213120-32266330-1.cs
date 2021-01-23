    private void nation_team_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<Object> e)
    {
        TreeViewItem rootNode = (TreeViewItem)e.NewValue;
        for (int i = 0; i < 3; ++i)
        {
            rootNode.Items.Add(new TreeViewItem() { Header = "some data" });
        }
    }
