    public class Direction
    {
        public static readonly Direction N = new Direction(0, 1);
        public static readonly Direction S = new Direction(0, -1);
        public static readonly Direction E = new Direction(1, 0);
        public static readonly Direction W = new Direction(-1, 0);
        private Direction(int stepSizeX, int StepSizeY)
        {
            this.StepSizeForXAxis = stepSizeX;
            this.StepSizeForYAxis = StepSizeY;
        }
        static Direction()
        {
            N.Left = W;
            N.Right = E;
            S.Left = E;
            S.Right = W;
            E.Left = N;
            E.Right = S;
            W.Left = S;
            W.Right = N;
        }
        public Direction Left { get; private set; }
        public Direction Right { get; private set; }
        public int StepSizeForXAxis { get; private set; }
        public int StepSizeForYAxis { get; private set; }
    }
