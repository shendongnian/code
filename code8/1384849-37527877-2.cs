    public class Program
    {
    	public static void Main()
    	{
    		var sv = new LineSegmentVisual();
    		sv.Descendants = new List<ISegmentVisual<Segment>> { new SquareSegmentVisual() };
    	}
    }
    
    
    abstract class Segment {}
    
    class LineSegment : Segment {}
    
    class SquareSegment: Segment {}
    
    interface ISegmentVisual<out TOwner>
    {
    	TOwner Owner { get; }
    	
    	List<ISegmentVisual<Segment>> Descendants { get; }
    }
    
    class LineSegmentVisual : ISegmentVisual<LineSegment>
    {
    	public LineSegment Owner { get; set; }
    	public List<ISegmentVisual<Segment>> Descendants { get; set; }
    }
    
    class SquareSegmentVisual : ISegmentVisual<SquareSegment>
    {
    	public SquareSegment Owner { get; set; }
    	public List<ISegmentVisual<Segment>> Descendants { get; set; }
    }
