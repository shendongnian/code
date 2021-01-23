	public class Size 
	{
		private readonly double _width;
		private readonly double _height;
		private readonly Unit _unit;
		public Size(double width, double height, Unit unit)
		{
			_width = width;
			_height = height;
			_unit = unit;
		}
		public double Width => _width;
		public double Height => _height;
		public Unit Unit => _unit;
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
