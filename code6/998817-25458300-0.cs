    public static class FoodMetaDataFactory
    {
        private static Dictionary<Food, IFood> _cache = new Dictionary<Food, IFood>();
        public static IFood GetMetaData(Food foodType)
        {  //takes a food enum value as a parameter
            IFood value;
            if (!_cache.TryGetValue(foodType, out value))
            {
                lock (_cache)
                {
                    if (!_cache.TryGetValue(foodType, out value))
                    {
                        var enumType = typeof(Food);
                        var memberInfo = enumType.GetMember(foodType.ToString());
                        var foodMetaDataAttributes = memberInfo[0].GetCustomAttributes(typeof(FoodMetaDataAttribute));
                        var targetType = ((FoodMetaDataAttribute)foodMetaDataAttributes[0]).MetaDataProviderType;
                        value = Activator.CreateInstance(targetType) as IFood;
                    }
                }
            }
            return value;
        }
    }
