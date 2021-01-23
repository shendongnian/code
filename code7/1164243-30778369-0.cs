    using System;
    using System.Collections.Generic;
    
    
    namespace Test{
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
            var POINTS = new List<double[]>(EDGES.Count * 2);
            FillPoints(EDGES, ref POINTS);
            for (int i = 0; i < POINTS.Count; i++)
            {
                Console.WriteLine("{0} {1} {2}", i, POINTS[i][0], POINTS[i][1]);
            }
            Console.WriteLine();
            var edgeIndices = new int[EDGES.Count, 2];
            FillEdges(EDGES, POINTS, ref edgeIndices);
            for (int i = 0; i < edgeIndices.GetLength(0); i++)
            {
                Console.WriteLine("({0}, {1})", edgeIndices[i, 0], edgeIndices[i, 1]);
            }
            Console.ReadKey(true);
        }
        static bool ListContainsPoint(List<double[]> POINTS, double[] POINT) 
        {
            bool found = false;
            for (int i = 0; i < POINTS.Count; i++)
            {
                var current = POINTS[i];
                if (current[0] == POINT[0] && current[1] == POINT[1]) 
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
        static int FindFirst(List<double[]> POINTS, double[] POINT) 
        {
            int index = -1;
            for (int i = 0; i < POINTS.Count; i++)
            {
                if (POINTS[i][0] == POINT[0] && POINTS[i][1] == POINT[1])
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        static void FillPoints(List<Edge> EDGES, ref List<double[]> POINTS) 
        {
            for (int i = 0; i < EDGES.Count; i++)
            {
                var current = EDGES[i];
                var firstPoint = new double[]{current.First.X, current.First.Y};
                var secondPoint = new double[]{current.Second.X, current.Second.Y};
                var firstCheck = ListContainsPoint(POINTS, firstPoint);
                var secondCheck = ListContainsPoint(POINTS, secondPoint);
                if (!firstCheck) POINTS.Add(firstPoint);
                if (!secondCheck) POINTS.Add(secondPoint);
            }
        }
        static void FillEdges(List<Edge> EDGES, List<double[]> POINTS, ref int[,] edgeIndices) 
        {
            for (int i = 0; i < EDGES.Count; i++) 
            {
                edgeIndices[i, 0] = FindFirst(POINTS, new double[] { EDGES[i].First.X, EDGES[i].First.Y });
                edgeIndices[i, 1] = FindFirst(POINTS, new double[] { EDGES[i].Second.X, EDGES[i].Second.Y });
            }
        }
    }
    }
