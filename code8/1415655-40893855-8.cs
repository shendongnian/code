    static void Main(string[] args) {
        var chartList = new List<Point> {
            new Point(50, 31), // x = 50, y = 31
            new Point(71, 87),
            new Point(71, 89),
            new Point(25, 66),
            new Point(94, 15),
            new Point(33, 94)
        };
        DrawChart(chartList);
        Console.ReadKey();
    }
