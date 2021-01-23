    public class ListManager
    {
        private readonly Dictionary<Type, IList> _lookup = new Dictionary<Type, IList>();
        public ListManager()
        {
            _lookup.Add(typeof(Car), new List<Car>());
            _lookup.Add(typeof(Bike), new List<Bike>());
        }
        public List<T> Get<T>()
        {
            return _lookup[typeof(T)] as List<T>;
        }
        public List<Car> Cars
        {
            get {  return Get<Car>(); }
        }
        public List<Bike> Bikes
        {
            get { return Get<Bike>(); }
        }
    }
