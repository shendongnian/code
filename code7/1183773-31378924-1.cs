            Point[] pts =  
            {
                new Point(10, 10),
                new Point(22, 11),
                new Point(16, 33),
                new Point(55, 8),
                new Point(4, 104)
            };
            pts = GetHighestXY(pts);
            foreach (Point item in pts)
            {
                Console.WriteLine("X : {0}  Y : {1} ", item.X, item.Y);
            }
