    class MyEnum
    {
        private static List<MyEnum> _values;
        public static Enumerable<MyEnum> Values {get { return _values.ToArray()}} 
        public static readonly FOO = new MyEnum('foo');
        public static readonly BAR = new MyEnum('bar')
    
        private MyEnum(string s)
        {
          //...
          _values.Add(this);
        }
    }
