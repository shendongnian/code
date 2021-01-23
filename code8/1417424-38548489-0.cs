    class SomeClass
    {
        public static class ObjectType
        {
            public const int A = 1;
            public const int B = 2;
            public const int C = 4;
            public const int D = 8;
        }
        public int MyType;
        public string Title;
        static void Main(string[] args)
        {
            List<SomeClass> list = new List<SomeClass>()
            {
                new SomeClass() {Title ="I am of type A", MyType = ObjectType.A }
                ,new SomeClass() {Title ="I am of type B", MyType = ObjectType.B }
                ,new SomeClass() {Title ="I am of type AB", MyType = ObjectType.A | ObjectType.B }
            };
            list.ForEach(p => { if (p.MyType == (ObjectType.A | ObjectType.B)) Console.WriteLine(p.Title); });
        }
    }
