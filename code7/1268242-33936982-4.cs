    private void DoWork(string check, bool enable)
    {
        for (int i = 1; i < 5; i++)
        {
            CheckBox CheckBox = (this.FindName(string.Format("{0}{1}",check, i)) as CheckBox);
            if (CheckBox != null)
            {
                CheckBox.IsChecked = enable;
            }
        }
    }
    private void Btn1_Click(object sender, RoutedEventArgs e)
    {
        DoWork("Check" , true);
    }
    private void BtnDisable1_Click(object sender, RoutedEventArgs e)
    {
        DoWork("Check_D" , false);
    }
