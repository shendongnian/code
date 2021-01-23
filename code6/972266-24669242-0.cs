    public class Nime<T1>
    {
        public static Nime<T1> Create(T1 item1)
        {
            return new Nime<T1>(item1); 
        }
    
        public T1 Item { get; set; }
    
        private Nime(T1 item)
        {
            Item = item;
        }
    }
