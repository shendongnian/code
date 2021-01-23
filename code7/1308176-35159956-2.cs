        public static void Main()
        {
            for( int i = 0; i < 10; i++ )
            {
                Console.Out.WriteLine( i );
                Console.Out.WriteLine( Test.Option1.ToString() );
            }
        }
        public enum Test
        {
            Option1,
            Option2,
            Option3
        }
