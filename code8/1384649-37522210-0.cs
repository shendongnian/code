    do
    {
        try
        {
             // the code you already have
        }
        catch (Exception ex)
        {
             Console.WriteLine("This is no valid input (" + ex.Message + ")! Try again...");
        }
    } while (UserChoice != 5);
