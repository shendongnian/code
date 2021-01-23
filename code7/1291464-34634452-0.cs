    using System;
    using System.Threading;
     namespace StackOverflowConsole
    {
        class Program
       {
         private static int SUM, PROD, x;
        public static void thread1( int[] a, int n )
        {
            int i = n;
            int sum = 0;
            for ( int j = 0; j < i; j++ )
            {
                sum = a[ j ] + sum;
            }
            Console.WriteLine( "\nThe sum is: " + sum );
            SUM = sum;
        }
        public static void thread2( int[] a, int n )
        {
            int prod = 1;
            for ( int j = 0; j < n; j++ )
            {
                prod = a[ j ] * prod;
            }
            Console.WriteLine( "\nThe product is: " + prod );
            PROD = prod;
        }
        public static void thread3()
        {
            Random rnd = new Random();
            int x;
            x = rnd.Next( -1000, 1000 );
            Console.WriteLine( "\nYour random number is: {0}", x );
            Program.x = x;
        }
        public static void thread4( int sum, int prod, int x )
        {
            Console.WriteLine( "\n" );
            if ( sum < prod && prod < x )
            {
                Console.WriteLine( "T1,T2,T3" );
            }
            else if ( sum < x && x < prod )
            {
                Console.WriteLine( "T1,T3,T2" );
            }
            else if ( x < sum && sum < prod )
            {
                Console.WriteLine( "T2,T1,T3" );
            }
            else if ( x < prod && prod < sum )
            {
                Console.WriteLine( "T2,T3,T1" );
            }
            else if ( prod < sum && sum < x )
            {
                Console.WriteLine( "T3,T1,T2" );
            }
            else if ( prod < sum && sum == x )
            {
                Console.WriteLine( "T3,T1=T2" );
            }
            if ( sum < prod && prod == x )
            {
                Console.WriteLine( "T1,T2==T3" );
            }
            else
                Console.WriteLine( "T3,T2,T1" );
        }
        static void Main( string[] args )
        {
            Random rnd = new Random();
            string s;
            int n;
            Console.WriteLine( "Give the size of the array: " );
            s = Console.ReadLine();
            n = int.Parse( s );
            int[] numbers = new int[ n ];
            for ( int i = 0; i < n; i++ )
            {
                numbers[ i ] = rnd.Next( -100, 100 );
            }
            Thread mythread1 = new Thread( delegate () { thread1( numbers, n ); } );
            mythread1.Start();
            Thread mythread2 = new Thread( delegate () { thread2( numbers, n ); } );
            mythread2.Start();
            Thread mythread3 = new Thread( () => thread3() );
            mythread3.Start();
            mythread1.Join();
            mythread2.Join();
            mythread3.Join();
            Thread mythread4 = new Thread( delegate () { thread4( SUM, PROD, x ); } );
            mythread4.Start();
            mythread4.Join();
            Console.ReadLine();
        }
    }
    }
