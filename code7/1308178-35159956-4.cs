        public static void Main()
        {
            TextWriter cons = Console.Out;
            for( int i = 0; i < 10; i++ )
            {
                cons.WriteLine( i );
                cons.WriteLine( Test.Option1.ToString() );
            }
        }
