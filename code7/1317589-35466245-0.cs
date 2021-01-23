    public class Item
    {
    }
    public class Item<T> : Item
    {
        T Value;
        public Item(T value)
        {
            Value = value;
        }
    }
