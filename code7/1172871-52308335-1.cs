    private void Check_Checked(object sender, RoutedEventArgs e)
        {
            this.LengthText.Text += (string)((CheckBox)sender).Content;
            MessageBox.Show(this.LengthText.Text);
        }
