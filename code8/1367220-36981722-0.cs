    if (!(double.TryParse(Waisttb.Text, out waist) && double.TryParse(Heighttb.Text, out height)))
    {
        // input is not a valid number
        MessageBox.Show("Please enter a vailable number!");
    }
    else if (waist < 0 || height < 0)
    {
        // numbers are valid, but negative
        MessageBox.Show("Please enter a vailable number!");
    } 
    else
    {
        // numbers are valid and positive. use them here
    }
