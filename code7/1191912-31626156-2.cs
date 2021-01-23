    int num = 1;
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (num <= ComboCounts)
        {
            ((ComboBox)this.FindName("comB" + num)).Visibility = Visibility.Visible;
            num++;
        }
    }
