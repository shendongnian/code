    private bool settingValue = false;
    private void AB_TextChanged(object sender, TextChangedEventArgs e)
    {
        if(!settingValue){
            settingValue = true;
            if (sender == A)
            {
                B.Text = (Convert.ToDouble(A.Text)*27).ToString("0.00");
            }
            else if (sender == B)
            {
                A.Text = (Convert.ToDouble(B.Text) /13).ToString("0.00");
            }
            settingValue = false;
        }
    }
