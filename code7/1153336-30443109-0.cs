     class Triangle
        {
            public double side1, side2, side3;
            public Triangle() { }
            public Triangle(double s1, double s2, double s3)
            {
                side1 = s1;
                side2 = s2;
                side3 = s3;
                if(side1 + side2 < side3)
                   throw new illegalTriangleException("Sum of any 2 sides not bigger than the other side");
                if(side1 + side3 < side2)
                   throw new illegalTriangleException("Sum of any 2 sides not bigger than the other side");
                if(side3 + side2 < side1)
                   throw new illegalTriangleException("Sum of any 2 sides not bigger than the other side");
            }
            public double Side1
            {
                get { return side1; }
                set {
                    if (value>0)
                    side1 = value;
                }
            }
            public double Side2
            {
                get { return side2; }
                set {
                    if (value > 0)
                    side2 = value;
                }
            }
            public double Side3
            {
                get { return side3; }
                set
                {
                    if (value > 0)
                    side3 = value;
                }
            }
        }
        
        class IllegalTriangleException : Exception
        {
            public IllegalTriangleException(string msg) : base(msg) { }
        }
        
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Console.WriteLine("Length of side: ");
                    double side1 = Convert.ToDouble(Console.ReadLine());
                    double side2 = Convert.ToDouble(Console.ReadLine());
                    double side3 = Convert.ToDouble(Console.ReadLine());
                    Triangle t = new Triangle(side1, side2, side3);
                    Console.WriteLine("Your triangle is puuuuurfect");
                }
                catch (IllegalTriangleException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
