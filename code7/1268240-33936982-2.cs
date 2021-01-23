    private void DoWork(Action action, string check)
    {
        for (int i = 1; i < 5; i++)
        {
            CheckBox CheckBox = (this.FindName(string.Format("{0}{1}",check, i)) as CheckBox);
            if (CheckBox != null)
            {
                action();
            }
        }
    }
    private void Btn1_Click(object sender, RoutedEventArgs e)
    {
        DoWork(() => CheckBox.IsChecked = true, "Check");
    }
    private void BtnDisable1_Click(object sender, RoutedEventArgs e)
    {
        DoWork(() => CheckBox1.IsChecked = false, "Check_D");
    }
