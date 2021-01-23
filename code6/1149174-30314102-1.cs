    public class Program
    {
    	static void Main(string[] args)
    	{ 
    		dynamic colors = new ExpandoObject();
    		colors.Red = ConsoleColor.Red;
    		Console.WriteLine(colors.Red);
    	}
    }
