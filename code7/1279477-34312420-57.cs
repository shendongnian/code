        private const int maxThreads = 10;
        private const int blockSize = 100;
        private static IEnumerable<Entity> entities;
        public static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            entities = Enumerable.Repeat(new Entity(), 1000).ToList();
            Action<EProperty[], int[]> testCase = RunTestCase;
            RunSelfTraining( testCase );
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            Console.WriteLine("Done.");
            Console.Read();
        }
        private static void RunTestCase( EProperty[] properties, int[] values ) 
        {         
            foreach( Entity entity in entities.Where( properties, values ) )
            {
            }
        }
        private static void RunSelfTraining<TEnum>( Action<TEnum[], int[]> testCase ) where TEnum : struct
        {
            ParallelOptions parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = maxThreads };
            for (int maskValue = 1; maskValue <= BitMask.GetMaxValue<EProperty>(); maskValue++)
            {
                TEnum mask = ( TEnum ) (object)maskValue;
                TEnum[] properties = mask.Split().ToArray();
                int blockCount = properties.Length;
                int[] maxValues = Enumerable.Repeat(blockSize, blockCount).ToArray();
                int valuePackages = BinaryConverter.Pack(maxValues, blockSize);
                Parallel.For(1, valuePackages, parallelOptions, valuePackage =>
                {
                    int[] values = BinaryConverter.UnPack(valuePackage, blockSize, blockCount);
                    testCase.Invoke(properties, values);        
                } );
            }
        }       
