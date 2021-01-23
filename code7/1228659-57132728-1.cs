    public class Program
    {
    	public static void Main(string[] args)
    	{
    		Console.WriteLine("enter 1 no.");
    		float i = Convert.ToInt32(Console.ReadLine());
    
    		Console.WriteLine("enter 2 no.");
    		float j = Convert.ToInt32(Console.ReadLine());
    
    		if (j % i == 0)
    		{
    			Console.WriteLine("devide no.is {0}", j);
    			Console.ReadLine();
    		}
    		else
    		{
    			Console.WriteLine("wrong input");
    		}
    	}
    }
