    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var listBox = sender as ListBox;
        var container = listBox.ContainerFromItem(listBox.SelectedItem) as ListBoxItem;
        var border = container.ContentTemplateRoot as Border;
        border.Background = new SolidColorBrush(Colors.Pink);
    }
