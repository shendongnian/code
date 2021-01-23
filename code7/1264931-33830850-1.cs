    // Say, all rectangles would be inside this "space"
    const int leftest = -1000;
    const int rightest = 1000;
    const int bottomest = -1000;
    const int toppest = 1000;
    . . .
    public enum CheckBy
    {
        Horizontal,
        Vertical
    }
    public class Node
    {
        public Node First { get; set; }
        public Node Second { get; set; }
        public int Coordinate { get; set; }
        public CheckBy CheckBy { get; set; }
        public List<Rectangle> Rectangles { get; set; }
    }
    . . .
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
    public bool IsRectangleInFist(Node node, Rectangle rectangle)
    {
        . . .
    }
    public bool IsRectangelInSecond(Node node, Rectangle rectangle)
    {
        . . .
    }
    // Sort rectangles by nodes
    public void AddRectangleInSuitableNode(Node node, Rectangle rectangle)
    {
        if (InRectangleInFirst(node, rectangle))
            AddRectangleInSuitableNode(node.First, rectangle);
        if (InRectangleInSecond(node, rectangle))
            AddRectangleInSuitableNode(node.Second, rectangle);
    }
    public void SearchIntersectedRectangles(Node node, Rectangle rectangle, List<Rectangles> result)
    {
        // If not-leaf node
        if (node.Rectangles == null && node.First != null && node.Second != null)
        {
            if (IsRectangleInFirst(node, rectangle))
                SearchIntersecatedRectangles(node.First, rectangle, result);
            if (IsRectangleInSecond(node, rectangle))
                SearchIntersecatedRectangles(node.Second, rectangle, result);
            return;
        }
        result.AddRangle(Rectangles.Where(r => r.IsIntersect(rectangle)));
    }
