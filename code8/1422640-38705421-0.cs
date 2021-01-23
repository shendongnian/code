    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public override string ToString() => $"X: {X}, Y: {Y}";
    }
    class Program
    {
        static void Main(string[] args)
        {
            var listA = new List<int> {1, 2, 3};
            var listB = new List<int>(listA);
            // Before the modification
            Console.WriteLine(listA[0]); // prints 1
            Console.WriteLine(listB[0]); // prints 1
            listA[0] = 2;
            // After the mofication
            Console.WriteLine(listA[0]); // prints 2
            Console.WriteLine(listB[0]); // prints 1
            Console.ReadKey();
            var pointsA = new List<Point>
            {
                new Point {X = 3, Y = 4},
                new Point {X = 4, Y = 5},
                new Point {X = 6, Y = 8},
            };
            var pointsB = new List<Point>(pointsA);
            // Before the modification
            Console.WriteLine(pointsA[0]); // prints X: 3, Y: 4
            Console.WriteLine(pointsB[0]); // prints X: 3, Y: 4
            pointsA[0].X = 4; 
            pointsA[0].Y = 3;
            // After the modification
            Console.WriteLine(pointsA[0]); // prints X: 4, Y: 3
            Console.WriteLine(pointsB[0]); // prints X: 4, Y: 3
            Console.ReadKey();
        }
    }
