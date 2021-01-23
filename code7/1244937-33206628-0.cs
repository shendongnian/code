    // this code block
    if (depositBtn.Checked == true); 
    {
        OutputInteger = (InputInteger + HoldInteger);
        outputTxt.Text = OutputInteger.ToString();
    } 
    //is identical to
    if (depositBtn.Checked == true)
    {
    }
    {
        OutputInteger = (InputInteger + HoldInteger);
        outputTxt.Text = OutputInteger.ToString();
    }
