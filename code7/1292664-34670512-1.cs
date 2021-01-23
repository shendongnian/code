    private void Button_Click(object sender, RoutedEventArgs e)
            {
                Frame f = new Frame();
                f.Source = new Uri("pack://application:,,,/Sliding/Page2.xaml", UriKind.Absolute);
    
                StkPnl.Children.Add(f);          
            }
