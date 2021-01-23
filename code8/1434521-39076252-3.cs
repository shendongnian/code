    public class Node
    {
        public double XPos { get; set; }
        public double YPos { get; set; }
    }
    public class TextNode : Node
    {
        public string Text { get; set; }
    }
    public class ShapeNode : Node
    {
        public Geometry Geometry { get; set; }
        public Brush Stroke { get; set; }
        public Brush Fill { get; set; }
    }
    public class ViewModel
    {
        public ObservableCollection<Node> Nodes { get; } = new ObservableCollection<Node>();
    }
