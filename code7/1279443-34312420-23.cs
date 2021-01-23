        private const int maxThreads = 100;
        private const int maxValue = 255;      
        public static void Main(string[] args)
        {
            List<Entity> entities = new List<Entity> { new Entity(), new Entity(), new Entity(), new Entity(), new Entity() }; 
            Parallel.For(1, Enums.GetMaxValue<EEntityValues>(), new ParallelOptions { MaxDegreeOfParallelism = maxThreads }, maskValue =>
            {
                EEntityValues mask = (EEntityValues) maskValue;
                IList<EEntityValues> properties = mask.Split().ToList();
                int totalPower = GetTotalPower( properties.Count());  
                Parallel.For(1, totalPower, new ParallelOptions { MaxDegreeOfParallelism = maxThreads }, currentPower =>
                {
                    foreach (Entity entity in entities)
                    {
                        if (SkipEntity(entity, properties, currentPower)) continue;
                    }
                });
            });
            Console.Read();
        }
        private static bool SkipEntity( Entity entity, IList<EEntityValues> properties, int currentPower)
        {
            bool result = false;              
            for( int index = 0; index <= properties.Count - 1; index++ )
            {
                EEntityValues property = properties[ index ];           
                int value = GetPowerValue(currentPower, index);     
                switch( property )
                {
                    case EEntityValues.Prop1:
                        result = entity.Prop1 < value;
                        break;
                    case EEntityValues.Prop2:
                        result = entity.Prop2 < value;
                        break;
                    case EEntityValues.Prop3:
                        result = entity.Prop3 < value;
                        break;
                    case EEntityValues.Prop4:
                        result = entity.Prop4 < value;
                        break;
                }
                if (result) break;
            }                                       
            return result;
        }
        private static int GetTotalPower(int propertyCount)
        {
            int result = 0;
            for (int i = 0; i < propertyCount; i++)
            {
                result += ( maxValue << 8 * i );
            }
            return result;
        }
        private static int GetPowerValue(int currentPower, int index )
        {
            return ( currentPower >> ( index * 8 ) ) & 0xFF;   
        }
