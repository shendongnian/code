    int tempNumber=0;
    if (int.TryParse(parsed[0], out tempNumber))
    {
        Textbox1.Text = " " + (tempNumber * 100 / 1023).ToString();
    }
    else 
    {
        Textbox1.Text= "invalid zipCode";
    }
