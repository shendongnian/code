    static void Main(string[] args)
    {
        try
        {
            Test();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    static void Test()
    {
        try
        {
            // long lambda chain
            new Action(() => new Action(() => new Action(() => { throw new InvalidOperationException(); })())())();
        }
        catch (Exception ex)
        {
            //throw;
            //throw ex;
        }
    }
