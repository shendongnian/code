    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class ConvexHull
    {
    private List<Vector2> vertices;
    public ConvexHull()
    {
        vertices = new List<Vector2>();
    }
    public ConvexHull(Vector2[] vertices)
    {
        this.vertices = new List<Vector2>(vertices);
    }
    public void AddVertices(Vector2[] vertices)
    {
        this.vertices.AddRange(new List<Vector2>(vertices));
    }
    public Vector2[] Generate()
    {
        if (vertices.Count > 1)
        {
            int k = 0;
            Vector2[] hull = new Vector2[2 * vertices.Count];
            // Make the list distinct and sorted
            vertices = vertices.Distinct().OrderBy(v => v.x).ToList();
            //vertices.Sort();
            //Array.Sort(vertices);
            // Build lower hull
            for (int i = 0; i < vertices.Count; ++i)
            {
                while (k >= 2 && Cross(hull[k - 2], hull[k - 1], vertices[i]) <= 0)
                    k--;
                hull[k++] = vertices[i];
            }
            // Build upper hull
            for (int i = vertices.Count - 2, t = k + 1; i >= 0; i--)
            {
                while (k >= t && Cross(hull[k - 2], hull[k - 1], vertices[i]) <= 0)
                    k--;
                hull[k++] = vertices[i];
            }
            if (k > 1)
            {
                hull = hull.Take(k - 1).ToArray();
            }
            return hull;
        }
        if (vertices.Count <= 1)
        {
            return vertices.ToArray();
        }
        return null;
    }
    private float Cross(Vector2 p1, Vector2 p2, Vector2 p3)
    {
        return (p2.x - p1.x) * (p3.y - p1.y) - (p2.y - p1.y) * (p3.x - p1.x);
    }
    }
