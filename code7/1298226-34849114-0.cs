    public abstract class Point
    {
		protected Point()
		{
		}
    	public static Point Create<T>(T x, T y)
    	{
    		if (typeof(T).IsAssignableFrom(typeof(int)))
    			return new Point2DI { X = (int)(object)x, Y = (int)(object)y };
    
    		if (typeof(T).IsAssignableFrom(typeof(double)))
    			return new Point2D { X = (double)(object)x, Y = (double)(object)y };
    
    		if (typeof(T).IsAssignableFrom(typeof(float)))
    			return new Point2DF { X = (float)(object)x, Y = (float)(object)y };
    
    		throw new Exception("Invalid type parameter");
    	}
    }
    
    public class Point2D : Point
    {
        public double X { get; set; }
    	public double Y { get; set; }
    }
    
    public class Point2DF : Point
    {
    	public float X { get; set; }
    	public float Y { get; set; }
    }
    
    public class Point2DI : Point
    {
    	public int X { get; set; }
    	public int Y { get; set; }
    }
