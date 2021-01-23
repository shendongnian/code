	public class Size 
	{
		public Size(double width, double height, Unit unit)
		{
			Width = width;
			Height = height;
			Unit = unit;
		}
		public double Width { get; }
		public double Height { get; }
		public Unit Unit { get; }
	}
