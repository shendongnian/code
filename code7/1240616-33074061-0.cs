    public class Program
    {
    	public void Main(string[] args)
    	{
    		List<dataStruct> objs = new List<dataStruct>(){
    			new dataStruct{direction = Direction.DOWN, id=1},
    			new dataStruct{direction = Direction.LEFT, id =2},
    			new dataStruct{direction = Direction.UP, id =3},
    		};
    		
    		var result = objs.OrderBy(x=>x.direction);
    		
    		foreach (var element in result)
    		{
    			Console.WriteLine ("{0}, {1}", element.direction, element.id);
    		}
    	}
    }
    
    public struct dataStruct
    {
    	public Direction direction;
    	public int id;
    	//other properties
    }
    
    public enum Direction
    {
      NONE, // SHOULD NEVER BE THIS
      UP,
      DOWN,
      LEFT,
      RIGHT
    };
