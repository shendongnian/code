    private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox kilo = (sender as ComboBox);
            int index = kilo.SelectedIndex;
            switch (kilo.ToString())
            {
                case "0":
                    //Method();
                    break;
                //...
            }
        }
