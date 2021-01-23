    int total = someValue;
    int finalTotal;
    private void radioEvent(object sender, EventArgs e)
    {
        if(radioOne.Checked)
        {
            finalTotal = total + 1;
        }
        if(radioTwo.Checked)
        {
            finalTotal = total + 11;
        }
    }
    
