    int input;    
    if (int.TryParse(inInt, out input))
    {
        //do something with the input.
    }
    else
    {
        MessageBox.Show("Only use numbers!");
    }
