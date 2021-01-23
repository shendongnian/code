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
    public bool IsRectangleInFist(Node node, Rectangle rectangle)
    {
        if (node.CheckBy == CheckBy.Horizontal)
            return rectangle.Left <= node.Coordinate;
        return rectangle.Top <= node.Coordinate;
    }
    public bool IsRectangelInSecond(Node node, Rectangle rectangle)
    {
        if (node.CheckBy == CheckBy.Horizontal)
            return rectangle.Right >= node.Coordinate;
        return rectangle.Bottom >= node.Coordinate;
    }
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
