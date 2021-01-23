    bool isChild;
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Hide();
        new MainWindow() { isChild = true }.ShowDialog();
        if (isChild)
        {
            ShowDialog();
        }
        else
        {
            Show();
        }
    }
