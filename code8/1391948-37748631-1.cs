    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
        var checkBox = (CheckBox)sender;
        var dc = checkBox.DataContext;
        var actualValue = (WeekDays)Enum.Parse(typeof(WeekDays), dc.ToString());
        int Value += (int)actualValue;
     }
