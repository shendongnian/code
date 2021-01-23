    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if(Menu3.Visibility == System.Windows.Visibility.Visible)
        {
            Menu3.Visibility = System.Windows.Visibility.Hidden;
            return;
        }
        Menu3.Visibility = System.Windows.Visibility.Visible;
    }
