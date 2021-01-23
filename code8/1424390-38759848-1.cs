    public class Oval:Shape
    {
    	
    	//Constructor
        public Oval(double majorAxis, double minorAxis)
        {
          MajorAxis=majorAxis;
          MinorAxis=minorAxis;
        } 
    	
    	protected double MajorAxis{ get; set; }
    	
    	protected double MinorAxis{ get; set; }
    	
    }
    
    
    public class Circle:Oval
    {
    	
    	//Constructor
        public Circle(double radius): base(radius,radius)
        {
          radius = Circle_Radius;  
        } //constructor
    	
    	public double Radius
    	{
    		get
    		{
    			return MajorAxis;
    		}
    		set
    		{
    			MajorAxis = value;
    			MinorAxis = value;
    		}
    	
    	}
    }
