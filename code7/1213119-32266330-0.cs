    private void nation_team_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<Object> e)
    {
        TreeViewItem rootNode = new TreeViewItem() { Header = nation_team.SelectedValue.ToString() };
        for (int i = 0; i < 3; ++i)
        {
            rootNode.Items.Add(new TreeViewItem() { Header = "some data" });
            nation_team.Items.Add(rootNode);
        }
    }
