        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox Selector = (sender as ComboBox);
            int index = Selector.SelectedIndex;
            switch (index)
            {
                case 0:
                    workOutKilo();
                    break;
                case 1:
                    workOutPounds();
                    break;
            }
        }
