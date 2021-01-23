    public class MyType : EnumClass
    {
        public static MyType FOO = new MyType(12, "Foo");
        public static MyType BAR = new MyType(13, "Bar");
        public static MyType X = new MyType(99, "X");
        [JsonConstructor]
        private MyType(int id, string name)
        {
            _id = id;
            _name = name;
        }
        public static MyType GetMyType(int id)
        {
            switch (id)
            {
                case 12: return FOO;
                case 13: return BAR;
                case 99: return X;
                default: return null;
            }
        }
        public static IEnumerable<MyType> GetMyTypes()
        {
            return new List<MyType>
            {
                FOO,
                BAR,
                X
            };
        }
    }
