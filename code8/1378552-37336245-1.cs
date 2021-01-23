    try
    {
        Customer cust = new Customer(-1, string.Empty);
    }
    catch(ArgumentException aex)
    {
        DoSomething(aex); // Log to database, file, or alike
        // Maybe display a message on the user
    }
    catch(Exception ex)
    {
        DoSomething(ex); // Log to database, file, or alike
        // Do generic error process here
    }
