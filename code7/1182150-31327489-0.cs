    public class Group
    {
        private Group(byte a, byte b, byte c)
        {
            A = a;
            B = b;
            C = c;
        }
        public byte A { get; private set; }
        public byte B { get; private set; }
        public byte C { get; private set; }
        public static readonly Group One = new Group(0, 1, 2);
        public static readonly Group Two = new Group(8, 16, 24);
    }
