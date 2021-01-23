    private void filterIDTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        string newValueIfAllowed = filterIDTextBox.Text + e.KeyChar.ToString();
        if (!Char.IsControl(e.KeyChar) 
            && (!Regex.IsMatch(e.KeyChar.ToString(), "[0-9A-Fa-f,]")
            || !Regex.IsMatch(newValueIfAllowed , "^([0-9A-Fa-f]{1,4},)*[0-9A-Fa-f]{0,4}$")))
        {
            e.Handled = true;
        }
    }
    
