	public sealed class Direction {
	
		public static readonly Direction N = new Direction(0, 1);
		public static readonly Direction S = new Direction(0, -1);
		public static readonly Direction E = new Direction(1, 0);
		public static readonly Direction W = new Direction(-1, 0);
		
		static Direction() {
			N.Left = W;
			N.Right = E;
			S.Left = E;
			S.Right = W;
			E.Left = N;
			E.Right = S;
			W.Left = S;
			W.Right = N;
		}
	
		private Direction(int stepSizeOnXAxis, int stepSizeOnYAxis)
		{
			StepSizeForXAxis = stepSizeOnXAxis;
			StepSizeForYAxis = stepSizeOnYAxis;
		}
	
		public Direction Right { get; private set; }
		public Direction Left { get; private set; }
	
		public int StepSizeForXAxis { get; }
		public int StepSizeForYAxis { get; }
	}
