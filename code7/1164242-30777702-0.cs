    using System;
    using System.Collections.Generic;
    namespace Test
    {
    struct Point
    {
        public readonly double X;
        public readonly double Y;
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
    struct Edge
    {
        public Point First;
        public Point Second;
        public Edge(Point First, Point Second)
        {
            this.First = First;
            this.Second = Second;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ///////////////////////////INPUT////////////////////////////////////
            var EDGES = new List<Edge>();
            EDGES.Add(new Edge(new Point(5, 50), new Point(20, 100))); //EDGE 01
            EDGES.Add(new Edge(new Point(20, 100), new Point(30, 50))); //EDGE 12
            EDGES.Add(new Edge(new Point(30, 50), new Point(10, 0))); //EDGE 23
            EDGES.Add(new Edge(new Point(5, 50), new Point(30, 50))); //EDGE 02
            EDGES.Add(new Edge(new Point(5, 50), new Point(10, 0))); //EDGE 03
            EDGES.Add(new Edge(new Point(20, 100), new Point(80, 100))); //EDGE 14
            EDGES.Add(new Edge(new Point(10, 0), new Point(80, 100))); //EDGE 34
            //FLL POINTS CACHE
            var distinctPoints = new List<Point>();
            foreach (Edge edge in EDGES)
            {
                if (!distinctPoints.Contains(edge.First))
                    distinctPoints.Add(edge.First);
                if (!distinctPoints.Contains(edge.Second))
                    distinctPoints.Add(edge.Second);
            }
            //POINTS LIST OUTPUT
            for (int i = 0; i < distinctPoints.Count; i++)
            {
                Console.WriteLine("{0} {1} {2}", i, distinctPoints[i].X, distinctPoints[i].Y);
            }
            //FILL 2D ARRAY OF INDICES
            int[,] edgeIndices = new int[EDGES.Count, 2];
            for (int i = 0; i < EDGES.Count; i++)
            {
                edgeIndices[i, 0] = distinctPoints.IndexOf(EDGES[i].First);
                edgeIndices[i, 1] = distinctPoints.IndexOf(EDGES[i].Second);
            }
            //2D ARRAY OUTPUT
            for (int i = 0; i < edgeIndices.GetLength(0); i++)
            {
                Console.WriteLine("({0}, {1})", edgeIndices[i, 0], edgeIndices[i, 1]);                
            }
            Console.ReadKey();
        }
    }
    }
