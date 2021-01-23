    public class C_Point
    {
        public string point;
        public double xPoint;
        public double yPoint;
        public C_Point(string n, double x, double y)
        {
            this.point = n;
            xPoint = x;
            yPoint = y;
        }
    }
    class Program
    {
       
        static void Main(string[] args)
        {
           List<C_Point> pointList = new List<C_Point>();
            pointList.Add(new C_Point("P1", 1, 11));
            pointList.Add(new C_Point("P1", 2, 22));
            pointList.Add(new C_Point("P1", 3, 33));
            pointList.Add(new C_Point("P10", 101, 111));
            pointList.Add(new C_Point("P10", 201, 211));
            pointList.Add(new C_Point("P10", 301, 311));
            // Select all the distinct names
            List<string> pointNames = pointList.Select(x => x.point).Distinct().ToList();
            foreach (var name in pointNames)
            {
                Console.WriteLine("Name: {0}", name);
                // Get all Values Where the name is equal to the name in List Select all xPoint Values
                double[] x_array = pointList.Where(n => n.point == name).Select(x => x.xPoint).ToArray();
                Console.WriteLine(String.Join(" ", x_array));
                // Get all Values Where the name is equal to the name in List Select all yPoint Values
                double[] y_array = pointList.Where(n => n.point == name).Select(x => x.yPoint).ToArray();
                Console.WriteLine(String.Join(" ", y_array));
            }
            Console.ReadKey();
        }
    }
