    try
    {
        int input = int.Parse(inInt);
        return input;
    }
    catch (FormatException e)
    {
         MessageBox.Show("Only use numbers! " + e.Message);
         //you may return something here to make your ParseInput compilable.
    }
