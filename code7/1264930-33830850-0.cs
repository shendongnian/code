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
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Coordinate { get; set; }
        public CheckBy CheckBy { get; set; }
        public List<Rectangle> Rectangles { get; set; }
    }
    . . .
    var tree = new Node
    {
        CheckBy = CheckBy.Hozirontal,
        Coordinate = (leftest + rightest)/2,
        Left = new Node
        {
            CheckBy = CheckBy.Vertical,
            Coordintate = (toppest + bottomest)/2,
            Rectangles = new List<Rectangle>(),
        },
        Right = new Node
        {
            CheckBy = CheckBy.Vertical,
            Coordintate = (toppest + bottomest)/2,
            Rectangles = new List<Rectangle>(),
        },
    }
