    class ImmutableTriangle
    {
        public ImmutableTriangle(double side1, double side2, double side3)
        {
            if(side1 + side2 <= side3 ||
               side2 + side3 <= side1 ||
               side3 + side1 <= side2)
                throw new IllegalTriangleException("Sum of any 2 sides not bigger than the other side");
            }
            if(side1 <= 0 || side2 <= 0 || side3 <= 0)
                throw new IllegalTriangleException("Sides must be positive");
            }
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }
        public double Side1 { get; private set; }
        public double Side2 { get; private set; }
        public double Side3 { get; private set; }
    }
