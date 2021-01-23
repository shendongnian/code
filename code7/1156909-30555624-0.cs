    struct ParseResult<T>
    {
        public bool Success { get; private set; }
        public T Value { get; private set; }
    
        public ParseResult(T value, bool success):this()
        {
            Value = value;
            Success = success;
        }
    }
    
    class Program
    {
        static ParseResult<int> TryParse(string s)
        {
            int lret = 0;
            if (int.TryParse(s, out lret))
            {
                return new ParseResult<int>(lret, true);
            }
            else
            {
                return new ParseResult<int>(lret, false);
            }
    
        }
    
        static void Main(string[] args)
        {
    
            string test = "1";
            var lret = TryParse(test);
            if( lret.Success )
            {
                Console.WriteLine("{0}", lret.Value);
            }
        }
    }
