    private void phoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
            {
                char character = Convert.ToChar(e.Text);
                if (char.IsNumber(character))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
    
            }
