    public class Direction
    {
        private Direction(int stepSizeX, int StepSizeY, Direction left, Direction right)
        {
            this.StepSizeForXAxis = stepSizeX;
            this.StepSizeForYAxis = StepSizeY;
            this.Left = left;
            this.Right = right;
        }
        public static readonly Direction N = new Direction(0, 1, W, E);
        public static readonly Direction S = new Direction(0, -1, E, W);
        public static readonly Direction E = new Direction(1, 0, N, S);
        public static readonly Direction W = new Direction(-1, 0, S, N);
        public Direction Left { get; }
        public Direction Right { get; }
        public int StepSizeForXAxis { get; }
        public int StepSizeForYAxis { get; }
    }
