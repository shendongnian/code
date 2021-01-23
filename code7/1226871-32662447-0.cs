	public class ReportPageParams
	{
		public float Width { get; protected set; }
		public float Height { get; protected set; }
		public float LeftMargin { get; protected set; }
		public float RightMargin { get; protected set; }
		public float TopMargin { get; protected set; }
		public float BottomMargin { get; protected set; }
		//Constructor
		public ReportPageParams(float pWidth, float pHeight) 
		{
			Width = 52f
			Height = 52f
			//...
		}
	}
	public class ReportPageParamsWithLargeLeftMargin : ReportPageParams
	{
		//Constructor
		public ReportPageParamsWithLargeLeftMargin(float pWidth, float pHeight)
			: base(pWidth, pHeight)
		{
			LeftMargin = 100;
		}
	}
