    private List<TextBox> dynamicGroupEdits = new List<TextBox>();
 
    private void AddNewButton_Click(object sender, RoutedEventArgs e)
    {
        ...
        dynamicGroupEdits.Add(GroupEdit);
        GroupEdit.Tag = dynamicGroupEdits.Count;
        GroupPanel.Tag = GroupEdit.Tag;
        GroupTextBox.Tag = GroupEdit.Tag;
        ...
    }
    private void GroupEdit_Click(object sender,RoutedEventArgs e)
    {
        ...
        tag = GroupEdit1.Tag;
        // Loop through all child controls and set visibility according to tag
        for each (var c in LogicalTreeHelper.GetChildren(GroupEdit1.Parent)
        {
            if(c is TextBox && c.Tag == tag) 
                c.Visible =Visibility.Visible;
            else if(c is TextBlock && c.Tag == tag) 
                c.Visibility = Visibility.Collapsed;
         }
    }
