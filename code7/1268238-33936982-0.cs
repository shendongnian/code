    private void DoWork(Action action)
    {
        for (int i = 1; i < 5; i++)
        {
            CheckBox CheckBox = (this.FindName(string.Format("Check{0}", i)) as CheckBox);
            if (CheckBox != null)
            {
                action();
            }
        }
    }
    private void Btn1_Click(object sender, RoutedEventArgs e)
    {
        DoWork(() => CheckBox.IsChecked = true);
    }
    private void BtnDisable1_Click(object sender, RoutedEventArgs e)
    {
        DoWork(() => CheckBox1.IsChecked = false);
    }
