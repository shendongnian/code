    static void Main(string[] args)
    {
        var time = 3;
        char myKey = 'q';
    
        // do some things ...
    
        var key = Console.ReadKey().KeyChar;
    
        if (key == myKey)
        {
            bool ok = true;
            for (int count = 0; count < time; count++)
            {
                key = Console.ReadKey().KeyChar;
                if (key != myKey)
                {
                    ok = false;
                    break;
                }
            }
    
            if (ok)
            {
                // do my work
            }
            else
            {
                // Do some else works ...
            }
        }
        else
        {
            // Do some else works ...
        }
    
    
        Console.ReadKey();
    }
