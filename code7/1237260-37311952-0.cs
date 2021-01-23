        public static void Main()
        {
            Point p = new Point();
            p.x = 7;
            object o = p;
            ((IModifiablePoint)o).Y = 9;   //  This works
            ((Point)o).Print();
        }
        interface IModifiablePoint
        {
            int X { get; set; }
            int Y { get; set; }
        }
        struct Point : IModifiablePoint
        {
            public int x, y;
            public int X
            {
                get { return x; }
                set { x = value; }
            }
            public int Y
            {
                get { return y; }
                set { y = value; }
            }
            public void Print()
            {
                System.Console.WriteLine("x= " + this.x + "\ny= " + this.y);
            }
        }
    }
