     private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tbSource = (sender as TextBox);
            
            if (lblOutput == null)
                return; 
            lblOutput.Content = tbSource.Text; 
        }
