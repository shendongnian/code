    public struct MutableStruct
    {
        public int Value { get; private set; }
        public void MutableMethod()
        {
            Value = 5;
        }
    }
