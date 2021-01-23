        class DelegatesTest
        {
            delegate int ComputeFunctionCallback( int x, int y );
    
            public static void Run()
            {
                string input = "";
                Console.Write( "Press 1 or 2:" ); input = Console.ReadLine();
    
                if ( input != "" )
                {
                    ComputeFunctionCallback compute = null;
    
                    switch ( input )
                    {
                        case "1":
                            Console.WriteLine( "You are using the Add Function" );
                            compute = Add;
                            break;
    
                        case "2":
                            Console.WriteLine( "You are using the Subtract Function" );
                            compute = Subtract;
                            break;
                    }
    
                    Console.WriteLine( "Result is {0}", compute( 5, 2 ) );
                }
            }
    
    
            static int Add( int a, int b )
            {
                return ( a + b );
            }
    
            static int Subtract( int a, int b )
            {
                return ( a - b );
            }
        }
