        private const int maxThreads = 10;
        private const int minValue = 0;
        private const int maxValue = 100;
        private static IEnumerable<Entity> entities;
        public static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            entities = Enumerable.Repeat(new Entity(), 10).ToList();
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
        private static void RunSelfTraining<T>( Action<T[], int[]> testCase ) where T : struct
        {
            ParallelOptions parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = maxThreads };
            for (int maskValue = 1; maskValue <= BitMask.GetMaxValue<T>(); maskValue++)
            {
                T mask = ( T ) (object)maskValue;
                T[] properties = mask.Split().ToArray();         
                                                                                        
                int variations = (int) Math.Pow(maxValue - minValue + 1, properties.Length);
                Parallel.For(1, variations, parallelOptions, variation =>
                {
                    int[] values = GetVariation(variation, minValue, maxValue, properties.Length).ToArray();   
                    testCase.Invoke(properties, values);        
                } );
            }
        }
        public static IEnumerable<int> GetVariation( int index, int minValue, int maxValue, int count )
        {
            index = index - 1; 
            int range = maxValue - minValue + 1;
            for( int j = 0; j < count; j++ )
            {
                yield return index % range + minValue;
                index = index / range;
            }
        }
    }
