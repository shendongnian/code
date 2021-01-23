    public static class WeightedRandomizer<T>
    {
        private static System.Random _random;
        static WeightedRandomizer()
        {
            _random = new System.Random();    
        }
        public static T PickRandom(List<WeightedItem<T>> items)
        {
            int totalWeight = items.Sum(item => item.Weight);
            int randomValue = _random.Next(1, totalWeight);
            int currentWeight = 0;
            foreach (WeightedItem<T> item in items)
            {
                currentWeight += item.Weight;
                if (currentWeight >= randomValue)
                    return item.Item;
            }
            return default(T);
        }
    }
