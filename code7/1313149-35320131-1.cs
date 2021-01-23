    public static class RandomExtensions
    {
		public static uint GetRandomBitOf( this Random rand, uint mask )
        {
            if( mask == 0 ) return 0;
        	var lo = smLookup[mask & 0xFFFF];
        	var hi = smLookup[mask >> 16];
        	int i = rand.Next( lo.Length + hi.Length );
        	return i < lo.Length ? (uint) lo[i] : (uint) hi[i - lo.Length] << 16;
		}
		
        static RandomExtensions()
        {
            smLookup = new ushort[65536][];
	
	        for( int i = 0; i < smLookup.Length; ++i )
			{
				ushort j = (ushort) i;
				smLookup[i] = Enumerable
					.Range( 0, 16 )
					.Select( b => (ushort) ( 1 << b ) )
					.Where( b => ( j & b ) != 0 )
					.ToArray();
			}
        }
        private static ushort[][] smLookup;
    }
