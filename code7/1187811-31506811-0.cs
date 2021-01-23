    public class MyEdge//used edges and notes for my graph
    {
        public int To { get; private set; }
        public int From { get; private set; }
        protected MyNode from;
        protected MyNode to;
        public MyEdge(int from, int to, MyGraph g)
        {
            From = from;
            To = to;
            this.from = g.GetNode(from);
            this.to = g.GetNode(to);
        }
        public MyNode NodeFrom()
        {
            return from;
        }
        public MyNode NodeTo()
        {
            return to;
        }
    }
    public class MyNode
    {
        public int Index { get; private set; }
        public Vector2D Pos { get; private set; }
        public List<MyEdge> Edges { get; private set; }
        public MyNode parent = null;
        public double G = double.MaxValue;
        public double H = 0;
        public double F { get { return G + H; } }
        public MyNode(int x, int y)
        {
            Edges = new List<MyEdge>();
            Pos = new Vector2D(x, y);
            Index = -1;
        }
        public MyNode(Vector2D pos)
        {
            Edges = new List<MyEdge>();
            Pos = pos;
            Index = -1;
        }
        public MyNode(int x, int y, int idx)
        {
            Edges = new List<MyEdge>();
            Pos = new Vector2D(x, y);
            Index = idx;
        }
        public MyNode(Vector2D pos, int idx)
        {
            Edges = new List<MyEdge>();
            Pos = pos;
            Index = idx;
        }
    }
