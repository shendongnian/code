    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        Height = ActualHeight;
        SizeToContent = System.Windows.SizeToContent.Manual;
        listbox.Height = Double.NaN;
    }
