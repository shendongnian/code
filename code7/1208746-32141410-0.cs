    class Triangle
    {
        Vector2 topPoint, rightPoint, leftPoint;
    
    
        public Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            topPoint = p1;
            rightPoint = p2;
            leftPoint = p3;
        }
    
    
    
        public bool IsRectIntersecting(List<Vector2> corners)//corners are the corners of the polygon being tested
        {
    
    
            if (AreAnyOfTheCornesInsideTriangleLineSegment(topPoint, rightPoint, corners) && 
                AreAnyOfTheCornesInsideTriangleLineSegment(rightPoint, leftPoint, corners) && 
                AreAnyOfTheCornesInsideTriangleLineSegment(leftPoint, topPoint, corners))
            {
                return true;
            }
    
            return false;
        }
    
        private bool AreAnyOfTheCornesInsideTriangleLineSegment(Vector2 pointA, Vector2 pointB, List<Vector2> corners)
        {
            Vector2 lineSegment = pointA - pointB;
            Vector3 lineSegment3D = new Vector3(lineSegment, 0);
            Vector3 normal3D = Vector3.Cross(lineSegment3D, Vector3.UnitZ);
            normal3D.Normalize();
            Vector2 normal = new Vector2(normal3D.X, normal3D.Y);
    
            foreach (Vector2 corner in corners)
            {
                if (Vector2.Dot(normal, corner - pointB) < 0)
                {
                    return true;
                }
            }
    
            return false;
        }
    }
