    public sealed class A
    {
        public readonly int X;
        public readonly int Y;
        public A(int x, int y)
        {
            X = x;
            Y = y;
        }
   
        public A With(int? X = null, int? Y = null) =>
            new A(
                X ?? this.X,
                Y ?? this.Y
            );
    }
