    public class Funker
    {
        public static Dictionary<string, string> _delegatesMapping;
        public static Dictionary<string, Func<int, int, int>> _delegates;
        public static Funker Instance { get; private set; }
        static Funker()
        {
            _delegatesMapping = new Dictionary<string, string>();
            _delegates = new Dictionary<string, Func<int, int, int>>();
            Instance = new Funker();
        }
        private Funker() { }
        public Func<int, int, int> this[Expression<Func<int, int, int>> del]
        {
            get
            {
                Expression<Func<int, int, int>> exp = del;
                string expStr = del.ToString();
                var parameters = del.Parameters;
                for (int i = 0; i < parameters.Count; i++)
                    expStr = expStr.Replace(parameters[i].Name, String.Concat('_' + i));
                if (!_delegatesMapping.ContainsKey(del.ToString()))
                    _delegatesMapping.Add(expStr, new String(expStr.OrderBy(ch => ch).ToArray()));                    
                if (!_delegates.ContainsKey(_delegatesMapping[expStr])) _delegates.Add(_delegatesMapping[expStr], del.Compile());
                return _delegates[_delegatesMapping[expStr]];
            }
        }
    }
