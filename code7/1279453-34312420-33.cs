        private const int MaxThreads = 10;
        private const int BlockSize = 100;
        public static void Main(string[] args)
        {
            List<Entity> entities = new List<Entity> { new Entity(), new Entity(), new Entity(), new Entity(), new Entity() };     
            Parallel.For(1, Enums.GetMaxValue<EProperty>(), new ParallelOptions {MaxDegreeOfParallelism = MaxThreads}, maskValue =>
            {
                EProperty mask = (EProperty) maskValue;
                IList<EProperty> properties = mask.Split().ToList();
                int[] values = Enumerable.Repeat( BlockSize, properties.Count() ).ToArray();
                int valuePackages = BinaryConverter.Pack( values, BlockSize ); 
                Parallel.For(1, valuePackages, new ParallelOptions {MaxDegreeOfParallelism = MaxThreads}, valuePackage =>
                {
                    foreach (Entity entity in entities)
                    {
                        if (SkipEntity(entity, properties, valuePackage ) ) continue;
                    }
                });
            });
            Console.WriteLine("Done.");
            Console.Read();
        }                               
        private static bool SkipEntity(Entity entity, IList<EProperty> properties, int valuePackage )
        {
            bool result = false;      
            int[] values = BinaryConverter.UnPack( valuePackage, BlockSize, properties.Count );
            for (int index = 0; index <= properties.Count - 1; index++)
            {
                EProperty property = properties[index];
                int value = values[index];       
                switch (property)
                {
                    case EProperty.Prop1:
                        result = entity.Prop1 < value;
                        break;
                    case EProperty.Prop2:
                        result = entity.Prop2 < value;
                        break;
                    case EProperty.Prop3:
                        result = entity.Prop3 < value;
                        break;
                    case EProperty.Prop4:
                        result = entity.Prop4 < value;
                        break;
                }
                if (result) break;
            }                              
            return result;
        }    
