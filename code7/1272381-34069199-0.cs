    using System;
    using System.Collections.Generic;
    using System.Drawing;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                var rawPoints = createRandomPoints(10000, 100, 100);
                int[] goodPointMap = new int[rawPoints.Length];
                var map = new Dictionary<Point, int>();
                var goodPoints = new List<Point>();
                for (int i = 0; i < rawPoints.Length; ++i)
                {
                    Point p = rawPoints[i];
                    int index;
                    if (map.TryGetValue(p, out index))
                    {
                        goodPointMap[i] = index;
                    }
                    else
                    {
                        map[p] = goodPoints.Count;
                        goodPointMap[i] = goodPoints.Count;
                        goodPoints.Add(p);
                    }
                }
                // At this point we no longer need 'map', which is used only to generate 'goodPoints[]'
                // and 'goodPointMap[]'.
                Console.WriteLine("Number of good points = " + goodPoints.Count);
                // Every point in rawPoints[] should have a point in goodPoints
                // which you can reference via goodPointMap[].
                // Let's verify that:
                for (int i = 0; i < rawPoints.Length; ++i)
                    if (rawPoints[i] != goodPoints[goodPointMap[i]])
                        Console.WriteLine("Failed!");
            }
            static Point[] createRandomPoints(int n, int maxX, int maxY)
            {
                var rng    = new Random();
                var result = new Point[n];
                for (int i = 0; i < n; ++i)
                    result[i] = new Point(rng.Next(maxX), rng.Next(maxY));
                return result;
            }
        }
    }
