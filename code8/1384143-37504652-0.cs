    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Point
    {
        int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
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
    }
    class Test
    {
        static void Main()
        {
            var collection = new List<Point>
            {
                new Point(1,1),
                new Point(1,2),
                new Point(1,1),
                new Point(1,2),
                new Point(3,3),
                new Point(4,5),
            };
            var result = collection.Where(a => collection.Count(b => b.X == a.X && b.Y == a.Y) == 1);
            foreach (var val in result)
                Console.WriteLine(val.X + "," + val.Y);
        }
    }
    //output:
    3,3
    4,5
