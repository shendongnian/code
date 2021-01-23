    //Regex
    Regex reg = new Regex(@"\D");
    if(reg.IsMatch(NumberTextBoxInput))
    {
        MessageBox.Show("Please enter a valid number.");
    }
    else
    {
        //Rest of method
    }
