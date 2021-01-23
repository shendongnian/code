    public class Point
    {
	   public int x;
  	   public int y;
	   public Point(int x, int y)
       {
		  this.x = x;
		  this.y = y;
	   }
    }
    public class PointComparer: IEqualityComparer<Point>
    {
	    public bool Equals(Point a, Point b)
	    {
		    if(a == null && b == null)
			   return true;
		    if(a== null || b== null)
			   return false;
		    return a.x == b.x && a.y == b.y;
	    }
	    public int GetHashCode(Point a)
        {
		   return (a.x.GetHashCode().ToString()+
           a.y.GetTypeCode().ToString()).GetHashCode();//A dummy hash
        }
    }	
