    static void Main()
    {
        const string msg = "Only 5 letters between a and j are allowed.";
        const string letters = "abcdefghij";
    
        Console.WriteLine( "Please Enter 5 Letters B/W a through j only:" );
    
        // read the entire input into a string
        string input = Console.ReadLine();
    
        // verify the input is the correct length.
        if( input == null || input.Length != 5 )
        {
            Console.WriteLine( msg );
            return;
        }
    
        // store the final result w/o duplicates in a string
        string result = string.Empty;
    
        // we know there are 5 and only 5 characters in the input string,
        // so just iterate over the entire string.
        foreach( char c in input )
        {
            string value = c.ToString();
    
            // check if the character exists in the allowable characters using
            // a case insensitive lookup.
            if( letters.IndexOf( value, StringComparison.OrdinalIgnoreCase ) < 0 )
            {
                // an invalid character was found, no need to continue.
                Console.WriteLine( value + " is inavlid." + msg );
                return;
            }
    
            // add the original character to the result string if it has yet to be added.
            if( !result.Contains( value ) )
            {
                result += value;
            }
        }
    
        Console.WriteLine( "You have entered the following inputs:" );
        Console.WriteLine( result );
    }
