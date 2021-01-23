    int num = 1;
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (num <= ComboCounts)//ComboCounts is count of your ComboBoxes
        {
            ((ComboBox)this.FindName("comB" + num)).Visibility = Visibility.Visible;
            num++;
        }
    }
