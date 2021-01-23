        private double side1, side2, side3;
        private Triangle() { }
        public Triangle(double s1, double s2, double s3)
        {
            side1 = s1;
            side2 = s2;
            side3 = s3;
            CheckForIllegalTriangle();
        }
        public double Side1
        {
            get { return side1; }
            set
            {
                if (value < 0)
                    side1 = value;
            }
        }
        public double Side2
        {
            get { return side2; }
            set
            {
                if (value < 0)
                    side2 = value;
            }
        }
        public double Side3
        {
            get { return side3; }
            set
            {
                if (value < 0)
                    side3 = value;
            }
        }
        public void CheckForIllegalTriangle()
        {
            if ((side1 + side2 < side3) ||
               (side1 + side3 < side2) ||
               (side3 + side2 < side1))
                throw new IllegalTriangleException("Sum of any 2 sides not bigger than the other side");
        }
    }
    class IllegalTriangleException : Exception
    {
        public IllegalTriangleException() : base("Sum of any 2 sides is not greater than the other") { }
        public IllegalTriangleException(string msg) : base("Sum of any 2 sides is not greater than the other" + msg) { }
        public IllegalTriangleException(string msg, Exception innerException) : base("Sum of any 2 sides is not greater than the other" + msg, innerException) { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Length of side 1: ");
                double side1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Length of side 2: ");
                double side2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Length of side 3: ");
                double side3 = Convert.ToDouble(Console.ReadLine());
                Triangle t1 = new Triangle(side1, side2, side3);
                Console.WriteLine("Your triangle is puuuuurfect");
            }
            catch (IllegalTriangleException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
