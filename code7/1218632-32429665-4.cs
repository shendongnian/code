    private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        SolidColorBrush b = new SolidColorBrush();
        b.Color = Color.FromRgb(255, 0, 255);
        Type t = ((ListBox)sender).SelectedItem.GetType();
        if(t == new ListBoxItem().GetType())
            ((ListBoxItem)((ListBox)sender).SelectedItem).Foreground = b;
    }
