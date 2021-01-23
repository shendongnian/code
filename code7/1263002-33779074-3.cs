    private void Button_Click(object sender, RoutedEventArgs e)
    {
       if(wrapPanel.Visibility!= System.Windows.Visibility.Hidden)
         wrapPanel.Visibility = System.Windows.Visibility.Hidden;
       else
         wrapPanel.Visibility = System.Windows.Visibility.Visible;
    }
