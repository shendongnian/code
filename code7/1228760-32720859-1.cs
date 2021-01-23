    private void RadioButton_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton.IsChecked.GetValueOrDefault())
            {
                rbEmpty.IsChecked = true;
                e.Handled = true;
            }
        }
