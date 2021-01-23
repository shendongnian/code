       private void EnDis(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        if(button.Name == "btnEnable_1")
        {
            chk_1.IsChecked = true;
            chk_2.IsChecked = true;
            chk_3.IsChecked = true;
            chk_4.IsChecked = true;
        }
            if(button.Name == "btnDisable_1")
        {
            chk_1.IsChecked = false;
            chk_2.IsChecked = false;
            chk_3.IsChecked = false;
            chk_4.IsChecked = false;
        }
    
        if(button.Name == "btnEnable_2")
        {
            chk_5.IsChecked = true;
            chk_6.IsChecked = true;
            chk_7.IsChecked = true;
            chk_8.IsChecked = true;
        }
    
    }
