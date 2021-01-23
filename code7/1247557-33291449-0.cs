        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var enabled = button.Name == "btnEnable_1";
            chk_1.IsChecked = enabled;
            chk_2.IsChecked = enabled;
            chk_3.IsChecked = enabled;
            chk_4.IsChecked = enabled;
            chk_5.IsChecked = !enabled;
            chk_6.IsChecked = !enabled;
            chk_7.IsChecked = !enabled;
            chk_8.IsChecked = !enabled;
        }
