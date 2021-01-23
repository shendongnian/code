            Toggle1.Checked += Toggle1_Checked;
            Toggle1.Unchecked += Toggle1_Unchecked;
            Toggle2.Checked += Toggle2_Checked;
            Toggle2.Unchecked += Toggle2_Unchecked;
        }
        private void Toggle2_Unchecked(object sender, RoutedEventArgs e)
        {
            Toggle1.IsChecked = true;
        }
        private void Toggle2_Checked(object sender, RoutedEventArgs e)
        {
            Toggle1.IsChecked = false;
        }
        private void Toggle1_Unchecked(object sender, RoutedEventArgs e)
        {
            Toggle2.IsChecked = true;
        }
        private void Toggle1_Checked(object sender, RoutedEventArgs e)
        {
            Toggle2.IsChecked = false;
        }
