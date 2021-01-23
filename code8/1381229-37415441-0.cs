    public static void Main()
    {
        object obj = null;
        decimal? nullDecimal = null;
        Test(obj);         // prints Something else
        Test(nullDecimal); // prints Nullable decimal
    }
    public static void Test<T>(T value)
    {
        if (typeof(T) == typeof(decimal))
        {
            Console.WriteLine("Decimal");
            return;
        }
        if (typeof(T) == typeof(decimal?))
        {
            Console.WriteLine("Nullable decimal");
            return;
        }
        Console.WriteLine("Something else");
    }
