    try
    {
        int input = int.Parse(inInt);
        return input;
    }
    catch (FormatException e)
    {
         MessageBox.Show("Only use numbers! " + ex.Message);
    }
