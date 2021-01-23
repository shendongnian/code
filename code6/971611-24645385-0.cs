    class Immutable
    {
        public readonly int Value;
        public Immutable(int value)
        {
            this.Value = value;
        }
        public static Immutable operator ++(Immutable obj)
        {
            return new Immutable(obj.Value + 1);
        }
    }
