    	public delegate IEnumerable< IEnumerable< int > > findSubset();
		public delegate bool findSubsetsIterativeFilter( int[] sourceSet, int[] indiciesToSum, int expected );
		public static bool Summ( int[] sourceSet, int[] indicies, int expected )
		{
			var sum = 0;
			for( int i = 0; i < indicies.Length; i++ )
				sum += sourceSet[ indicies[ i ] ];
			return sum == expected;
		}
		public static IEnumerable< IEnumerable< int > > findSubsetsIterative( int k, int[] sourceSet, findSubsetsIterativeFilter specialCondition, int expected )
		{
			var a = new int[ k ];
			for( int i = 0; i < k; i++ )
				a[ i ] = i; 
			var p = k - 1;
			while( p >= 0 )
			{
				if( specialCondition( sourceSet, a, expected ) )
					yield return ( int[] )a.Clone();
				p = ( a[ k - 1 ] == sourceSet.Length - 1 ) ? p - 1 : k - 1;
				if( p >= 0 )
					for( int i = k - 1; i >= p; i-- )
						a[ i ] = a[ p ] + i - p + 1;
			}
		}
        ...
    	   findSubsetsIterative( 2, a, Summ, 293 );
