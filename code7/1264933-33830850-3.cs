    // Say, all rectangles would be inside this "space"
    const int leftest = -1000;
    const int rightest = 1000;
    const int bottomest = -1000;
    const int toppest = 1000;
    // Tree with depth == 2
    var tree = new Node
    {
        CheckBy = CheckBy.Hozirontal,
        Coordinate = (leftest + rightest)/2,
        First = new Node
        {
            CheckBy = CheckBy.Vertical,
            Coordintate = (toppest + bottomest)/2,
            Rectangles = new List<Rectangle>(),
        },
        Second = new Node
        {
            CheckBy = CheckBy.Vertical,
            Coordintate = (toppest + bottomest)/2,
            Rectangles = new List<Rectangle>(),
        },
    }
