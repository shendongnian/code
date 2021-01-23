    abstract class Pagination2<T>
    {
        public string Property1 { get; set; }
        public List<T> Items { get; set; }
        public static Pagination2<T> GetInstance<T>()
        {
            Pagination2<T> instance = new Pagination2<T>()
            {
                Items = new List<T>()
            };
            return instance;
        } 
    }
    
