    private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        SolidColorBrush b = new SolidColorBrush();
        b.Color = Color.FromRgb(255, 0, 255);
        ((ListBoxItem)((ListBox)sender).SelectedItem).Foreground = b;
    }
