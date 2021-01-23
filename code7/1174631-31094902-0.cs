    public static void incr (   int a ) // a = 3
    {
        int aResult;
        //++a
        a = a + 1; // a = 4
        aResult = a; //aResult = 4
        Console.WriteLine (aResult ); //  prints 4
        //a++
        aResult = a; //aResult = 4
        a = a + 1; //a = 5
        Console.WriteLine (aResult); // prints 4 because the result was copied before the increment.
    }
