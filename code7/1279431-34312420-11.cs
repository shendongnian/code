        public static void Main(string[] args)
        {
            List<Entity> entities = new List<Entity> { new Entity(), new Entity(), new Entity(), new Entity(), new Entity() };
            // Iterate all possible property combinations
            Parallel.For(1, Enums.GetMaxValue<EEntityValues>(), maskValue =>
            {
                EEntityValues mask = (EEntityValues) maskValue;
                
                // Split the bitmask into properties.
                IList<EEntityValues> properties = mask.Split().ToList(); 
                // Count all possible property value tests.
                // maxValue = property value range
                int totalPower = maxValue.Pow(properties.Count());
                // Run the property tests
                Parallel.For(1, totalPower, currentPower =>
                {
                    foreach (Entity entity in entities)
                    {
                        // Skip non matching entities first
                        if (SkipEntity(entity, properties, currentPower)) continue;
                        // Do some more tests and store the result
                    }
                });
            });
        }
        private static bool SkipEntity( Entity entity, IList<EEntityValues> properties, int currentPower)
        {
            bool result = false;
            for( int index = 0; index <= properties.Count - 1; index++ )
            {
                EEntityValues property = properties[ index ];
                // Get the value to compare the selected property with
                int value = currentPower.Pow( 1 / ( index + 1 ) );     
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
