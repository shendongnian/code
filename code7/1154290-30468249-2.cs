    private static void Main()
    {
        try
        {
            new ItsATrap();
            Environment.Exit(0);
        }
        catch (Exception ex)
        {
            Console.WriteLine("During exit: {0}", ex);
        }
    }
    private class ItsATrap
    {
        ~ItsATrap()
        {
            throw new InvalidOperationException("Ooops!");
        }
    }
