	class Graph : View
	{
		List<int> speedvalues  ;
		public Graph(Context c , string speedvalues ) : base(c)
		{
		   
           this.peedvalues = new List<int>(StringToListInt(speedvalues));
		   this.SetBackgroundColor(Color.White);
           
		}
	}
