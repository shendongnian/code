    int count = 0;
    private void CheckBox_Click(object sender, RoutedEventArgs e)
    {
        var chekBox = (sender as CheckBox).IsChecked;
        if (chekBox==true)
        {
            count = count + 1;
        }
        if (count > 1)
        {
            (sender as CheckBox).IsChecked = false;
            count = 0;
        }
    }
