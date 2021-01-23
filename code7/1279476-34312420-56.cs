    public static class QueryBuilder
    {
        public static IEnumerable<Entity> Where(this IEnumerable<Entity> entities, EProperty[] properties, int[] values)
        {
            IEnumerable<Entity> result = entities.Select(e => e);
            for (int index = 0; index <= properties.Length - 1; index++)
            {
                EProperty property = properties[index];
                int value = values[index];
                switch (property)
                {
                    case EProperty.Prop1:
                        result = result.Where(e => Math.Abs(e.Prop1) >= value);
                        break;
                    case EProperty.Prop2:
                        result = result.Where(e => Math.Abs(e.Prop2) >= value);
                        break;
                    case EProperty.Prop3:
                        result = result.Where(e => Math.Abs(e.Prop3) >= value);
                        break;              
                }
            }
            return result;
        }
    }
