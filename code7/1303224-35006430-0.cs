    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "readLines.txt";
            IEnumerable<string> lines = null;
            List<Triangle> triangles = new List<Triangle>();
            lines = File.ReadLines(fileName);
            foreach(var line in lines)
            {
                string[] lineValues = line.Split(',');
                triangles.Add(new Triangle(
                    new Point(int.Parse(lineValues[0]), int.Parse(lineValues[1])),
                    new Point(int.Parse(lineValues[2]), int.Parse(lineValues[3])),
                    new Point(int.Parse(lineValues[4]), int.Parse(lineValues[5]))));
            }  
            Console.ReadLine();
        }
    }
    public class Triangle
    {
        public Point point1;
        public Point point2;
        public Point point3;
        public Triangle(Point point1, Point point2, Point point3)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;
        }
    }
    public class Point
    {
        public Point(int x, int y)
        {
        }
    }
