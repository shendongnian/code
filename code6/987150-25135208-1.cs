    private void Button_Click(object sender, RoutedEventArgs e)
    {
    	ctrl1.Visibility = Visibility.Visible;
    	ctrl2.Visibility = Visibility.Collapsed;
    	ctrl3.Visibility = Visibility.Collapsed;
    }
    
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
    	ctrl2.Visibility = Visibility.Visible;
    	ctrl1.Visibility = Visibility.Collapsed;
    	ctrl3.Visibility = Visibility.Collapsed;
    }
    
    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
    	ctrl3.Visibility = Visibility.Visible;
    	ctrl1.Visibility = Visibility.Collapsed;
    	ctrl2.Visibility = Visibility.Collapsed;
    }
