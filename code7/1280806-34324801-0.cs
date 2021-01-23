    class Program
    {
        static void Main(string[] args)
        {
            int [] items = { 150 , 78 , 44 } ;
            int x = Program.Pack ( items , 150 ) ;
            int [] unpacked = Program.UnPack ( x , 150 , 3 ) ;
        }
        public static int Pack ( int[] blocks , int blockSize )
        {
            int size = (int)Math.Ceiling(Math.Log(blockSize, 2));
            int len = size * blocks.Length;
            if (len > 32)
                throw new Exception("Int Limit Exceeded");
            if ( blocks.Any ( x => x > blockSize ) )
                throw new Exception ( "There are some blocks that exceede the maximum block size" );
            List<bool> bools = new List<bool>();
            bools = bools.InitBoolArray(32);
            int i = 0 ;
            foreach (int block in blocks)
            {
                BitArray temp = block.ToBinary().Take(size);
                for ( int j = 0 ; j < size ; i++ , j++ )
                    bools[i] = temp.Get(j);
            }
            return (new BitArray ( bools.ToArray() ) ).ToNumeral() ;
        }
        public static int[] UnPack ( int entry , int blockSize , int blockCount )
        {
            BitArray number = entry.ToBinary();
            int size = (int)Math.Ceiling(Math.Log(blockSize, 2));
            if (size > 32)
                throw new Exception("Int Limit Exceeded");
            List<int> result = new List<int>();
            for (int i = 0; i < blockCount; i++)
            {
                BitArray temp = number.Take(size);
                number = number.Shift (size );
                result.Add(temp.FitSize(32).ToNumeral());
            }
            return result.ToArray() ;
        }
    }
