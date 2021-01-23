    private void DoWork(int checkboxGroup, bool enable)
    {
        int start = checkboxGroup * 4;
        for (int i = start; i < start + 4; i++)
        {
            CheckBox CheckBox = this.FindName("CheckBox{0}" + i) as CheckBox;
            if (CheckBox != null)
            {
                CheckBox.IsChecked = enable;
            }
        }
    }
    private void Btn1_Click(object sender, RoutedEventArgs e)
    {
        DoWork(1 , true);
    }
    private void BtnDisable1_Click(object sender, RoutedEventArgs e)
    {
        DoWork(1 , false);
    }
