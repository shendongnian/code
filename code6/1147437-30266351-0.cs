    <ListBox x:Name="ListBox1"  ...>
        <ListBox.ItemTemplate>
            <DataTemplate>
                <StackPanel ...>
                    <CheckBox x:Name="checkBox" ... />
                    <TextBlock  ... />
                </StackPanel>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
    // To select list item and change Picked value to true.
    private void ListBox1_DoubleTapped(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
    {
        // Find the index;
        int i = ListBox1.SelectedIndex;
        CheckBox checkBox = getCheckBox(ListBox1);
        try
        { 
            // Change Picked bool value.
            item.Picked = true;
            // Check CheckBox to show item selected.
            checkBox.IsChecked = true;
        }
        catch (NullReferenceException exc) { }
    }
    // Taken and modified from Jerry Nixon. http://blog.jerrynixon.com/2012/09/how-to-access-named-control-inside-xaml.html
    // Find the checkBox for that ListBox item.
    CheckBox getCheckBox(ListBox ListBox1)
    {
        var _ListBoxItem = ListBox1.SelectedItem;
        var _Container = ListBox1.ItemContainerGenerator.ContainerFromItem(_ListBoxItem);
        var _Children = AllChildren(_Container);
        var _Name = "checkBox";
        var _Control = (CheckBox)_Children.First(c => c.Name == _Name);
        return _Control;
    }
    // Taken and modified from Jerry Nixon. http://blog.jerrynixon.com/2012/09/how-to-access-named-control-inside-xaml.html
    // Get any child controls from ListItem Container.
    // Using a visual tree to access elements on the page
    // within the xaml heirarchy of nested elements/tags.
    public List<Control> AllChildren(DependencyObject parent)
        {
        var _List = new List<Control> { };
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            var _Child = VisualTreeHelper.GetChild(parent, i);
            if (_Child is Control)
                _List.Add(_Child as Control);
            _List.AddRange(AllChildren(_Child));
        }
        return _List;
	}
