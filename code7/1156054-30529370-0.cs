	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	namespace ConsoleApplication4
	{
    class arraymod
    {
        static void Main( string[] args )
        {
            int[] values;
            values = new int[ 10 ];
            Random rand = new Random();
            for( int i = 0 ; i < 10 ; i++ )
            {
                values[ i ] = rand.Next( 1 , 20 );
            }
            Array.Sort( values );
            for( int i = 0 ; i < 10 ; i++ )
            {
                Console.WriteLine( values[ i ] );
            }
            Console.WriteLine( "Min: {0}" , values.Min() );
            Console.WriteLine( "Max: {0}" , values.Max() );
            Console.WriteLine( "Sum: {0}" , values.Sum() );
            Console.WriteLine( "Mean: {0}" , Mean( values ) ); //call
            Console.WriteLine( "Median: {0}" , Median( values ) );//call
        }
        //make method "Mean" static
        public static int Mean( int[] arr )
        {
            int valuesMean = arr.Sum() / arr.Count();
            return valuesMean;
        }
        //make method "Median" static
        public static int Median( int[] arr )
        {
            int valuesMedian = ( arr.Max() + arr.Min() ) / 2;
            return valuesMedian;
        }
    }
	}
