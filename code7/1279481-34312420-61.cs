    public static class BinaryConverter
    {
        public static int Pack( int[] blocks, int blockSize )
        {
            int size = ( int ) Math.Ceiling( Math.Log( blockSize, 2 ) );
            int len = size * blocks.Length;
            if( len > 32 )
                throw new Exception( "Int Limit Exceeded" );
            if( blocks.Any( x => x > blockSize ) )
                throw new Exception( "There are some blocks that exceede the maximum block size" );
            List<bool> bools = new List<bool>();
            bools = bools.InitBoolArray( 32 );
            int i = 0;
            foreach( int block in blocks )
            {
                BitArray temp = block.ToBinary().Take( size );
                for( int j = 0; j < size; i++, j++ )
                    bools[ i ] = temp.Get( j );
            }
            return ( new BitArray( bools.ToArray() ) ).ToNumeral();
        }
        public static int[] UnPack( int entry, int blockSize, int blockCount )
        {
            BitArray number = entry.ToBinary();
            int size = ( int ) Math.Ceiling( Math.Log( blockSize, 2 ) );
            if( size > 32 )
                throw new Exception( "Int Limit Exceeded" );
            List<int> result = new List<int>();
            for( int i = 0; i < blockCount; i++ )
            {
                BitArray temp = number.Take( size );
                number = number.Shift( size );
                result.Add( temp.FitSize( 32 ).ToNumeral() );
            }
            return result.ToArray();
        }
        public static BitArray ToBinary(this int numeral)
        {
            return new BitArray(new[] {numeral});
        }
        public static int ToNumeral(this BitArray binary)
        {
            if (binary == null) throw new ArgumentNullException(nameof(binary));
            if (binary.Length > 32) throw new ArgumentException("must be at most 32 bits long");
            var result = new int[1];
            binary.CopyTo(result, 0);
            return result[0];
        }
        public static BitArray Take(this BitArray current, int length)
        {
            if (current.Length < length) throw new Exception("Invalid length parameter");
            List<bool> taken = new List<bool>();
            for (int i = 0; i < length; i++) taken.Add(current.Get(i));
            return new BitArray(taken.ToArray());
        }
        public static BitArray Shift(this BitArray current, int length)
        {
            if (current.Length < length) throw new Exception("Invalid length parameter");
            List<bool> shifted = new List<bool>();
            for (int i = 0; i < current.Length - length; i++) shifted.Add(current.Get(length + i));
            return new BitArray(shifted.ToArray());
        }
        public static BitArray FitSize(this BitArray current, int size)
        {
            List<bool> bools = new List<bool>();
            bools = bools.InitBoolArray(size);
            for (int i = 0; i < current.Count; i++) bools[i] = current.Get(i);
            return new BitArray(bools.ToArray());
        }
        public static List<bool> InitBoolArray(this List<bool> current, int size)
        {
            List<bool> bools = new List<bool>();
            for (int i = 0; i < size; i++) bools.Add(false);
            return bools;
        }
    }
