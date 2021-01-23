       int ComboNO = 0;
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ComboNO++;
            if (ComboNO==1)            comB1.Visibility = Visibility.Visible;
            else if (ComboNO == 2)     comB2.Visibility = Visibility.Visible;
            else if (ComboNO == 3)     comB3.Visibility = Visibility.Visible;
        }
