    public interface IRunnable<T>
    {
        void Run();
        T Value {get;}
    }
    public class LineNode : IRunnable<Line>
    {
        [Input]
        public Point a;
        [Input]
        public Point b;
  
        private Line line;
        public Line Value { get{return line;}}
        public override void run()
        {
        line = new Line(a, b);
        // draw line ...
        }
}
