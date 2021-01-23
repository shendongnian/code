    public class WeightedItem<T>
    {
        public T Item { get; set; }
        public int Weight { get; set; }
        public WeightedItem(T item, int weight=1)
        {
            Item = item;
            Weight = weight;
        }
    }
