    private void filterIDTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!Char.IsControl(e.KeyChar) 
            && !Regex.IsMatch(filterIDTextBox.Text, "^([0-9A-Fa-f]{1,4},)*[0-9A-Fa-f]{0,4}$"))
        {
            e.Handled = true;
        }
    }
    
