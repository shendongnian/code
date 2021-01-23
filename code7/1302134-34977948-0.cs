    class Graph : View
    {
        List<int> speedvalues;
        List<PointF> graphpoints = new List<PointF>();
        int padding = 100;
    	bool isReady = false;
    
        public Graph(Context c) : base(c)
        {
        this.SetBackgroundColor(Color.White);
        }
    
        public float MaxSpeed()
        { [...] }
    
        public static List<int> StringToListInt(string x)
        { [...] }                   
    
        public void GraphPoints()
        { [...] }                   
    
    	public void ReadyToDraw(bool ready)
    	{
    		isReady=ready;
    	}
    	
    	public static List<int> StringToListInt(string x)
        { 
    		speedvalues=new List<int>(StringToListInt(x));
    	} 
    	
        protected override void OnDraw(Canvas cv)
        { 
    	 base.OnDraw(canvas);
    	if(ReadyToDraw)
    	{
    	//Your drawing code
    	}
    	}
    }
