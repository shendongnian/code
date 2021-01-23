    namespace V1
    {
        // https://stackoverflow.com/questions/31552724/how-why-does-xmlserializer-treat-a-class-differently-when-it-implements-ilistt
        public class Vector2
        {
            public double X { get; set; }
            public double Y { get; set; }
            public Vector2() { }
            public Vector2(double x, double y)
                : this()
            {
                this.X = x;
                this.Y = y;
            }
            public double this[int coord]
            {
                get
                {
                    switch (coord)
                    {
                        case 0:
                            return X;
                        case 1:
                            return Y;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                set
                {
                    switch (coord)
                    {
                        case 0:
                            X = value;
                            break;
                        case 1:
                            Y = value;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }
    }
