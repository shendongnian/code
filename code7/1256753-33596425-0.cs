    someTabControl.Loaded += (s, e) =>
    {
        TabControl tc = (TabControl)sender;
        FrameworkElement root = (FrameworkElement)VisualTreeHelper.GetChild(tc, 0);
        TabPanel headerPanel = root.FindName("HeaderPanel") as TabPanel;
        if (headerPanel != null) 
        {
            Console.WriteLine(headerPanel.ActualHeight);
        }
    };
