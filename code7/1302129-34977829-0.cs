	class Graph : View
	{
		List<int> speedvalues  ;
		List<PointF> graphpoints = new List<PointF>();
		int padding = 100;
		public Graph(Context c , string speedvalues ) : base(c)
		{
		this.peedvalues = new List<int>(StringToListInt(speedvalues));
		this.SetBackgroundColor(Color.White);
		}
	}
