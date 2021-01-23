    private void label_MouseDown(object sender, MouseButtonEventArgs e)
    {
    if (e.LeftButton == MouseButtonState.Pressed)
    {
        DragMove();
        if (WindowState == System.Windows.WindowState.Maximized)
            WindowState = System.Windows.WindowState.Normal;
    }
    }
