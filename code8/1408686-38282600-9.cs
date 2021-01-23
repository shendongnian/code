    static void Main( string[ ] args )
    {
        int input = int.Parse( Console.ReadLine() );
        int zeroes = 0;
        List<int> myList = ATM( input );
        foreach ( var zero in myList )
        {
            if ( zero == 0 )
            {
                zeroes += 1;
            }
        }
        Console.WriteLine( zeroes );
        Console.ReadKey();
        Console.ReadKey();
    }
