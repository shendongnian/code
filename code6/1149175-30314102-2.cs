    public class Program
    {
    	static void Main(string[] args)
    	{ 
    		var colors = new List<Color>
    		{
    			new Color{ Color = ConsoleColor.Black, Name = "Black"},
    			new Color{ Color = ConsoleColor.Red, Name = "Red"},
    		}; 
            Console.WriteLine(colors[0].Color);
    	}
    }
    
    public class Color
    {
    	public ConsoleColor Color { get; set; }
    	public String Name { get; set; }
    }
