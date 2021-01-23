    internal class Program
    {
        static void Main()
        {
            string example = "Spencer the Cat";
            UsesNeverNull neverNullUser = new UsesNeverNull(example);
            Console.WriteLine(neverNullUser.TheString);
            neverNullUser.TheString = null;
            Debug.Assert(neverNullUser.TheString != null);
            Console.WriteLine(neverNullUser.TheString);
            neverNullUser.TheString = "Maximus the Bird";
            Console.WriteLine(neverNullUser.TheString);
        }
      
    }
    public class UsesNeverNull
    {
        public string TheString
        {
            get { return _stringValue.Value; } 
            set { _stringValue.Value = value; }
        }
        public UsesNeverNull(string s)
        {
            TheString = s;
        }
        private readonly NeverNull<string> _stringValue = new NeverNull<string>(string.Empty, str => str ?? string.Empty); 
    }
    public class NeverNull<T> where T : class
    {
        public NeverNull(T initialValue, Func<T, T> nullProtector)
        {
            if (nullProtector == null)
            {
                var ex = new ArgumentNullException(nameof(nullProtector));
                throw ex;
            }
            _value = nullProtector(initialValue);
            _nullProtector = nullProtector;
        } 
        public T Value
        {
            get { return _nullProtector(_value); }
            set { _value = _nullProtector(value); }
        }
        private T _value;
        private readonly Func<T, T> _nullProtector;
    }
