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
		public Size ConvertTo(Unit unit)
		{
			Size convertedSize;
			switch(unit) 
			{
				case Unit.Inch:
					// Calc here the conversion from current Size
					// unit to inches, and return
					// a new size
					convertedSize = new Size(...);
					break;
				case Unit.Pixel:
					// Calc here the conversion from current Size 
					// unit to pixels, and return
					// a new size
					convertedSize = new Size(...);
					break;
				default:
					throw new NotSupportedException("Unit not supported yet");
					break;
			}
			return convertedSize;
		}
	}
