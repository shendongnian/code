    private void AnyColumnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
    
            // allow 1 dot:
    
    
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
    			if ( (sender as TextBox).Text != "." ) {
    				e.Handled = true;
    			}
            }
    
    
    
        }
