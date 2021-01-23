    public class DemoClass
    {
        //static List<DemoClass> _currentList = null;
        static List<DemoClass> _currentList = new List<DemoClass>();
        static bool _isScopeStarted = false;
        public DemoClass()
        {
            if (_isScopeStarted)
            {
                _currentList.Add(this);
            }
        }
        
        public int a { get; set; }
        public int b { get; set; }
        public static IEnumerable<DemoClass> ScopeObjects
        {
            get
            {
                return _currentList;
            }
        }
        public int Sum()
        {
            return a + b;
        }
        public static void StartScope()
        { 
            //_currentList = new List<DemoClass>();            
            _isScopeStarted = true;
        }
        public static void EndScope()
        {
            //_currentList = null;
            _currentList = new List<DemoClass>();
        }
