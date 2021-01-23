	public class Program
	{
		public static void Main()
		{			
			function f = x => 50 / (10 + x * x);	
			
			// 9.41404285216233
			Console.Out.WriteLine(new RiemannMidpointSum(6).FindIntegral(1, 4, f));	
			
			// 9.41654853716462
			Console.Out.WriteLine(new RiemannMidpointSum(1E-2).FindIntegral(1, 4, f));
			
			// 9.41654853716462
			Console.Out.WriteLine(Program.FindIntegral(1, 4, f));	
		}
		
		// This is your function.
		public static double FindIntegral (double start, double end, function f)
		{
			double sum = 0;
			double stepsize = 1E-2;
			int numSteps = (int)((end - start) / stepsize);
			for (int i = 0; i < numSteps; i++)
			{
				sum += f(start +  (stepsize * (i + 0.5)));
			}
			return sum * stepsize;
		}	
	}
		
	public delegate double function(double d);
	
	public class RiemannMidpointSum
	{
		private int? _numberOfRectangles;
		private double? _widthPerRectangle;
		
		public RiemannMidpointSum(int numberOfRectangles)
		{
			// TODO: Handle non-positive input.
			this._numberOfRectangles = numberOfRectangles;
		}
		
		public RiemannMidpointSum(double widthPerRectangle)
		{
			// TODO: Handle non-positive input.
			this._widthPerRectangle = widthPerRectangle;
		}
		
		public double FindIntegral(double a, double b, function f)
		{		
			var totalWidth = b - a;
			var widthPerRectangle = this._widthPerRectangle ?? (totalWidth / this._numberOfRectangles.Value);
			var numberOfRectangles = this._numberOfRectangles ?? ((int)Math.Round(totalWidth / this._widthPerRectangle.Value, 0));
			
			double sum = 0;		
			foreach (var i in Enumerable.Range(0, numberOfRectangles))
			{
				var rectangleMidpointX = a + widthPerRectangle * i + widthPerRectangle / 2;			
				var rectangleHeightY = f(rectangleMidpointX);
				var rectangleArea = widthPerRectangle * rectangleHeightY;
				
				sum += rectangleArea;
			}		
			
			return sum;
		}
	}
