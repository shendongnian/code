    class Triangle
    {
        private double _side1, _side2, _side3;
        public Triangle() { }
        public Triangle(double s1, double s2, double s3)
        {
            side1 = s1;
            side2 = s2;
            side3 = s3;
        }
        public double Side1
        {
            get { return _side1; }
            set {
                if (value < 0 && CheckForIllegalTriangle())
                side1 = value;
            }
        }
        public double Side2
        {
            get { return _side2; }
            set {
                if (value < 0 && CheckForIllegalTriangle())
                side2 = value;
            }
        }
        public double Side3
        {
            get { return _side3; }
            set
            {
                if (value < 0 && CheckForIllegalTriangle())
                side3 = value;
            }
        }
        private void CheckForIllegalTriangle() {
            if((side1 + side2 < side3) || 
               (side1 + side3 < side2) || 
               (side3 + side2 < side1))
               throw new illegalTriangleException("Sum of any 2 sides not bigger than the other side");
            }
        }
    }
