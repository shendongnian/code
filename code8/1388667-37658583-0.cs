    using System.Drawing;
    using System.Drawing.Drawing2D;
    class Program
    {
        static void Main(string[] args)
        {
            List<PointF> points = new List<PointF>();
            points.Add(new PointF(30.5f, 15.6f));
            points.Add(new PointF(25.4f, 5f));
            points.Add(new PointF(0, 20));
            float y = 11f;
            for (int x = 0; x < 30; x++)
            if (IsInPolygon(points, new PointF(x, y))) 
                Console.WriteLine("(" + x + ", y) is inside");
            Console.ReadLine();
        }
        public static bool IsInPolygon(List<PointF> points, PointF location)
        {
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddPolygon(points.ToArray());
                return gp.IsVisible(location);
            }
        }
    }
