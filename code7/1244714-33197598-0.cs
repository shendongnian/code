    public class ListManager
    {
        private readonly Dictionary<Type, IList> _lookup = new Dictionary<Type, IList>();
        public ListManager()
        {
            _lookup.Add(typeof(Car), Cars);
            _lookup.Add(typeof(Bike), Bikes);
        }
        public List<T> Get<T>()
        {
            return _lookup[typeof(T)] as List<T>;
        }
        public List<Car> Cars { get; set; }
        public List<Bike> Bikes { get; set; }
    }
