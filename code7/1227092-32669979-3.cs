    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < 10; i++)
        {
            Button b = new Button();
            b.Tag = i;
            b.Click += B_Click;
            sp_Container.Children.Add(b);
        }
    }
    
    private void B_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show((sender as Button).Tag.ToString());
    }
