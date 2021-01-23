    class Wrapper<T>
    {
        public T Item;
        public Wrapper(T item)
        {
            Item = item;
        }
        public static implicit operator Wrapper<T>(T item)
        {
            return new Wrapper<T>(item);    
        }
    }
