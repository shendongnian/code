    string txtTemp = "";
        private void changedText(object sender, TextChangedEventArgs e)
        {
        Regex regex = new Regex(@"^\d{1,4}$");
        
    string txtToTest = txtNumber.Text;
     
        if (regex.IsMatch(txtToTest)|| txtNumber.Text=="")
        {
	//do nothing 
        }
        else
        {
            txtNumber.Text = txtTemp;
            txtNumber.Select(txtNumber.Text.Length, 0);
        }
        
	//Save the current value to resume it if the next input was invalid
        txtTemp = txtNumber.Text;
    }
