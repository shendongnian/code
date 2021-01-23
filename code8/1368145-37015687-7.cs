    void Main()
    {
        var list = new List<Point>
        {
            new Point(1, 2),
            new Point(1, 1),
            new Point(1, 3),
        };
        
        // result: Point[] (3 items) : (1, 1), (1, 2), (1,3)
        list.GetPermutations()
            .OrderBy(x => x.GetTotalCost())
            .First();
    }
