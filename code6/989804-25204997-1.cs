        public static IList<Vector3> GrahamScanCompute(IList<Vector3> initialPoints)
        {
            if (initialPoints.Count < 2)
                return initialPoints.ToList();
            // Find point with minimum y; if more than one, minimize x also.
            int iMin = Enumerable.Range(0, initialPoints.Count).Aggregate((jMin, jCur) =>
            {
                if (initialPoints[jCur].Y < initialPoints[jMin].Y)
                    return jCur;
                if (initialPoints[jCur].Y > initialPoints[jMin].Y)
                    return jMin;
                if (initialPoints[jCur].X < initialPoints[jMin].X)
                    return jCur;
                return jMin;
            });
            // Sort them by polar angle from iMin, 
            var sortQuery = Enumerable.Range(0, initialPoints.Count)
                .Where((i) => (i != iMin)) // Skip the min point
                .Select((i) => new KeyValuePair<double, Vector3>(Math.Atan2(initialPoints[i].Y - initialPoints[iMin].Y, initialPoints[i].X - initialPoints[iMin].X), initialPoints[i]))
                .OrderBy((pair) => pair.Key)
                .Select((pair) => pair.Value);
            List<Vector3> points = new List<Vector3>(initialPoints.Count);
            points.Add(initialPoints[iMin]);     // Add minimum point
            points.AddRange(sortQuery);          // Add the sorted points.
            int M = 0;
            for (int i = 1, N = points.Count; i < N; i++)
            {
                bool keepNewPoint = true;
                if (M == 0)
                {
                    // Find at least one point not coincident with points[0]
                    keepNewPoint = !NearlyEqual(points[0], points[i]);
                }
                else
                {
                    while (true)
                    {
                        var flag = WhichToRemoveFromBoundary(points[M - 1], points[M], points[i]);
                        if (flag == RemovalFlag.None)
                            break;
                        else if (flag == RemovalFlag.MidPoint)
                        {
                            if (M > 0)
                                M--;
                            if (M == 0)
                                break;
                        }
                        else if (flag == RemovalFlag.EndPoint)
                        {
                            keepNewPoint = false;
                            break;
                        }
                        else
                            throw new Exception("Unknown RemovalFlag");
                    }
                }
                if (keepNewPoint)
                {
                    M++;
                    Swap(points, M, i);
                }
            }
            // points[M] is now the last point in the boundary.  Remove the remainder.
            points.RemoveRange(M + 1, points.Count - M - 1);
            return points;
        }
        static void Swap<T>(IList<T> list, int i, int j)
        {
            if (i != j)
            {
                T temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
        public static double RelativeTolerance { get { return 1e-10; } }
        public static bool NearlyEqual(Vector3 a, Vector3 b)
        {
            return NearlyEqual(a.X, b.X) && NearlyEqual(a.Y, b.Y);
        }
        public static bool NearlyEqual(double a, double b)
        {
            return NearlyEqual(a, b, RelativeTolerance);
        }
        public static bool NearlyEqual(double a, double b, double epsilon)
        {
            // See here: http://floating-point-gui.de/errors/comparison/
            if (a == b)
            { // shortcut, handles infinities
                return true;
            }
            double absA = Math.Abs(a);
            double absB = Math.Abs(b);
            double diff = Math.Abs(a - b);
            double sum = absA + absB;
            if (diff < 4*double.Epsilon || sum < 4*double.Epsilon)
                // a or b is zero or both are extremely close to it
                // relative error is less meaningful here
                return true;
            // use relative error
            return diff / (absA + absB) < epsilon;
        }
        static double CCW(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            // Compute (p2 - p1) X (p3 - p1)
            double cross1 = (p2.X - p1.X) * (p3.Y - p1.Y);
            double cross2 = (p2.Y - p1.Y) * (p3.X - p1.X);
            if (NearlyEqual(cross1, cross2))
                return 0;
            return cross1 - cross2;
        }
        enum RemovalFlag
        {
            None,
            MidPoint,
            EndPoint
        };
        static RemovalFlag WhichToRemoveFromBoundary(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            var cross = CCW(p1, p2, p3);
            if (cross < 0)
                // Remove p2
                return RemovalFlag.MidPoint;
            if (cross > 0)
                // Remove none.
                return RemovalFlag.None;
            // Check for being reversed using the dot product off the difference vectors.
            var dotp = (p3.X - p2.X) * (p2.X - p1.X) + (p3.Y - p2.Y) * (p2.Y - p1.Y);
            if (NearlyEqual(dotp, 0.0))
                // Remove p2
                return RemovalFlag.MidPoint;
            if (dotp < 0)
                // Remove p3
                return RemovalFlag.EndPoint;
            else
                // Remove p2
                return RemovalFlag.MidPoint;
        }
