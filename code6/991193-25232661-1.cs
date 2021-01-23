        public static void Main()
        {
            Vector2 p1 = new Vector2(288, 815);
            Vector2 p2 = new Vector2(1078, 890);
            //Please notice order of points is changed to clockwise
            IList<Vector2> Polygon = new List<Vector2>(new Vector2[] { new Vector2(262.8f, 669.1f), new Vector2(200.4f, 895.4f), new Vector2(1817.8f, 1540.8f), new Vector2(1623.9f, 718.2f) });
            bool p1Result = PointInsideRect2D(p1, Polygon);
            bool p2Result = PointInsideRect2D(p2, Polygon);
        }
        private static bool PointInside2D(Vector2 point, Vector2 lineStart, Vector2 lineEnd)
        {
            var v1 = lineStart - point;
            var edge = lineStart - lineEnd;
            return !(edge.X * v1.Y - edge.Y * v1.X < 0);
        }
        private static bool PointInsideRect2D(Vector2 point, IList<Vector2> rect)
        {
            var lastPoint = rect.Count - 1;
            bool? lastResult = null;
            for (var i = 0; i < lastPoint; ++i)
            {
                if (lastResult == null)
                {
                    lastResult = PointInside2D(point, rect[i], rect[i + 1]);
                }
                else
                {
                    if (lastResult != PointInside2D(point, rect[i], rect[i + 1]))
                    {
                        return false;
                    }
                }
            }
            return lastResult == PointInside2D(point, rect[lastPoint], rect[0]);
        }
