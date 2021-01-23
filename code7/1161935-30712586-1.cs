    public class LineNode : Node
    {
        [Input]
        public Point a;
        [Input]
        public Point b;
        [Output]
        public Line line;
        [Output]
        public override object DefaultOutput { get { return line; } }
        public override void run()
        {
            line = new Line(a, b);
            // draw line ...
        }
    }
