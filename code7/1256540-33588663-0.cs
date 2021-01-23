    public class Direction
    {
        private Direction(int stepSizeX, int StepSizeY)
        {
            this.StepSizeForXAxis = stepSizeX;
            this.StepSizeForYAxis = StepSizeY;
        }
        public static readonly Direction N = new Direction(0, 1)  { Left = W, Right = E };
        public static readonly Direction S = new Direction(0, -1) { Left = E, Right = W };
        public static readonly Direction E = new Direction(1, 0)  { Left = N, Right = S };
        public static readonly Direction W = new Direction(-1, 0) { Left = S, Right = N };
        public Direction Left { get; private set; }
        public Direction Right { get; private set; }
        public int StepSizeForXAxis { get; private set; }
        public int StepSizeForYAxis { get; private set; }
    }
