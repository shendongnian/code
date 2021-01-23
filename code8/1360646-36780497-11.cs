    public struct ImmutableStruct
    {
        public ImmutableStruct(int f1, string f2, object f3)
        {
            Field1 = f1;
            Field2 = f2;
            Field3 = f3;
        }
        public int Field1 { get; }
        public string Field2 { get; }
        public object Field3 { get; }
    }
