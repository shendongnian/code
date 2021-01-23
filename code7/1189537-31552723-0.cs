    public class EditorSelectionTool : PropertyChangedBase 
	{
		private double _x;
		private double _y;
		private double _width;
		private double _height;
		private Visibility _visibility;
		public double X
		{
			get { return _x; }
			set
			{
				_x = value;
				NotifyOfPropertyChange(()=> X);
			}
		}
		public double Y
		{
			get { return _y; }
			set
			{
				_y = value;
				NotifyOfPropertyChange(() => Y);
			}
		}
		public double Width
		{
			get { return _width; }
			set
			{
				_width = value;
				NotifyOfPropertyChange(() => Width);
			}
		}
		public double Height
		{
			get { return _height; }
			set
			{
				_height = value;
				NotifyOfPropertyChange(() => Height);
			}
		}
		public Visibility Visibility
		{
			get { return _visibility; }
			set
			{
				_visibility = value;
				NotifyOfPropertyChange(() => Visibility);
			}
		}
	}
