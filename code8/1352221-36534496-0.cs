    private void MIExit_click(object sender, RoutedEventArgs e)
    {
        if (MessageBox.Show("close?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            Application.Current.Shutdown();
        else return;
    }
