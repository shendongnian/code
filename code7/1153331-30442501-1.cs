    class Triangle
    {
        private double _side1, _side2, _side3;
        public Triangle() { }
        public Triangle(double side1, double side2, double side3)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }
        public double Side1
        {
            get { return _side1; }
            set {
                if (value < 0 && CheckForIllegalTriangle(value, Side2, Side3))
                side1 = value;
            }
        }
        public double Side2
        {
            get { return _side2; }
            set {
                if (value < 0 && CheckForIllegalTriangle(Side1, value, Side3))
                side2 = value;
            }
        }
        public double Side3
        {
            get { return _side3; }
            set
            {
                if (value < 0 && CheckForIllegalTriangle(Side1, Side2, value))
                side3 = value;
            }
        }
        private void CheckForIllegalTriangle(double side1, double side2, double side3) {
            if((side1 + side2 < side3) || 
               (side1 + side3 < side2) || 
               (side3 + side2 < side1))
               throw new illegalTriangleException("Sum of any 2 sides not bigger than the other side");
            }
        }
    }
