    public class ListManager
    {
        private Dictionary<Type, IList> _lookup
            = new Dictionary<Type, IList>();
        public ListManager()
        {
            _lookup.Add(typeof(Car), new List<Car>());
            _lookup.Add(typeof(Bike), new List<Bike>());
        }
        public List<Car> Cars
        {
            get { return (List<Car>)_lookup[typeof(Car)]; }
        }
        public List<Bike> Bikes
        {
            get { return (List<Bike>)_lookup[typeof(Bike)]; }
        }
        public void Add<T>(T obj)
        {
            if(!_lookup.ContainsKey(typeof(T))) throw new ArgumentException("obj");
            var list = _lookup[typeof(T)];
            list.Add(obj);
        }
    }
