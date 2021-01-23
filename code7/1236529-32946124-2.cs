    public class Funker
    {
        public static Dictionary<string, Func<int, int, int>> _delegates;
        public static Funker Instance { get; private set; }
        static Funker()
        {
            _delegates = new Dictionary<string, Func<int, int, int>>();
            Instance = new Funker();
        }
        private Funker() { }
        public Func<int, int, int> this[Expression<Func<int, int, int>> del]
        {
            get
            {
                Expression<Func<int, int, int>> exp = del;
                string function = del.ToString();
                if (!_delegates.ContainsKey(function)) _delegates.Add(function, del.Compile());
                return _delegates[function];
            }
        }
    }
