    public sealed class A
    {
        public readonly X X;
        public readonly Y Y;
        public A(X x, Y y)
        {
            X = x;
            Y = y;
        }
   
        public A With(X X = null, Y Y = null) =>
            new A(
                X ?? this.X,
                Y ?? this.Y
            );
    }
