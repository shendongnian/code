    ListViewItem item = (ListViewItem)(ListView1.ItemContainerGenerator.ContainerFromIndex(ListView1.SelectedIndex));
    if (item != null)
    {
        item.Foreground = new SolidColorBrush(Colors.Red);
    }
