    public class Program
    {
    	public static void Main(string[] args)
    	{
    		    int number;
                string inputData = Console.ReadLine();
    
                if(int.TryParse(inputData, out number))
                {
                    if (number > 0)
    				{ 
    					Console.WriteLine("You typed " + number + ". This is a postive value");
                    	Console.ReadLine();
    				}
                    else if (number < 0) 
    				{
    					Console.WriteLine("You typed" + number+ ". This is a negative value");
                    	Console.ReadLine();
    				}
                    else
    				{
    					Console.WriteLine("You typed" + number + " (zero).");
                    	Console.ReadLine();
    				}
                }
                else
                {
                  Console.WriteLine("The input was not a valid integer.");
                }
    	}
    }
