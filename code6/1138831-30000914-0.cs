    private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtBox2.IsEnabled = true;
                txtBox2.Focus();
            }
        }
        private void txtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!txtBox.Text.Equals(""))
            {
                txtBox2.IsEnabled = true;
            }
            else
            {
                txtBox2.IsEnabled = false;
            }
        }
