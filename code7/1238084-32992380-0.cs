    enum SomeEnum {
        X1,
        X2, 
        X3
    }
    
    enum SomeOtherEnum
    {
        X1,
        X2,
        X3,
        X4,
        X5
    }
    
    public static void SomeFunction(SomeEnum someEnum))
    
    {
    
        SomeEnum x = SomeEnum.X3; // some dummy init
        try
        {
            x = (SomeEnum) someEnum;
        }
        catch (InvalidCastException) 
        {
            Console.WriteLine("Exception"); // why no exception caught ? why legit cast ?
        }
        Console.WriteLine(x);
    }
        private static void Main(string[] args)
        {
            SomeFunction(SomeOtherEnum.X5); // pass a different type than the one in the function
            Console.ReadKey();
        }
