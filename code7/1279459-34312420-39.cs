        private const int MaxThreads = 10;
        private const int BlockSize = 100;
        public static void Main(string[] args)
        {
            Console.WriteLine( DateTime.Now.ToLongTimeString() );
            ParallelOptions parallelOptions = new ParallelOptions {MaxDegreeOfParallelism = MaxThreads};
            List<Entity> entities = Enumerable.Repeat( new Entity(), 100 ).ToList();
                                                                                              
            Parallel.For( 1, Enums.GetMaxValue<EProperty>(), parallelOptions, maskValue =>
            {
                EProperty mask = (EProperty) maskValue;
                EProperty[] properties = mask.Split().ToArray();
                int[] maxValues = Enumerable.Repeat( BlockSize, properties.Length ).ToArray();
                int valuePackages = BinaryConverter.Pack( maxValues, BlockSize ); 
                Parallel.For(1, valuePackages, parallelOptions, valuePackage =>
                {
                    int[] values = BinaryConverter.UnPack( valuePackage, BlockSize, properties.Length );
                    foreach( Entity entity in entities.Where( properties, values ) )
                    {                          
                    }
                });
            });
            Console.WriteLine( DateTime.Now.ToLongTimeString() );
            Console.WriteLine("Done.");
            Console.Read();
        }   
