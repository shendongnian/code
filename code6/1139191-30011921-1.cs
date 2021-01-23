    public enum StructType
    {
        Velocity = 0,
        Position = 1,
        Foo = 2,
        Bar = 3,
    }
    public struct Velocity
    {
        public int Vx;
        public int Vy;
    }
    public struct Position
    {
        public int X;
        public int Y;
        public int Z;
    }
    public struct Foo
    {
        public double Weight;
        public double Height;
        public int Age;
    }
    public struct Bar
    {
        public int ColorR;
        public int ColorG;
        public int ColorB;
        public int Transparency;
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct SuperStruct
    {
        [FieldOffset(0)]
        public StructType StructType;
        [FieldOffset(4)]
        public Velocity Velocity;
        [FieldOffset(4)]
        public Position Position;
        [FieldOffset(4)]
        public Foo Foo;
        [FieldOffset(4)]
        public Bar Bar;
    }
