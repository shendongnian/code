    public bool MyMethod()
    {
        try
        {
            return HasErrorsButReturnsOnlyIfTrue();
        }
        catch
        {
            // Some more code
            Console.WriteLine("Test");
            return false;
        }
    }
    public bool HasErrorsButReturnsOnlyIfTrue()
    {
        if (some condition)
            return true;
        else
            throw new Exception();
    }
