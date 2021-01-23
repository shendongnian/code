    namespace ConsoleApplication2
    {
    	public class Program
    	{
    		public static void Main()
    		{
    				PrimeNumbers(100);
    		}
    		
    		public static string PrimeNumbers(int n)
    			{
    				string result = n.ToString();
    				try
    				{
    					for (int i = 2; i < n; i++)
    					{
    						int rest = n % i;
    						if (rest == 0)
    						{
    							result = n + "isn't a prime number";
    							i = n + 1;
    						}
    						else
    						{
    							result = n + "it's a prime number";
    						}
    					}
    				}
    				catch (Exception e)
    				{
    					Console.WriteLine("Error checking prime number");
    					Console.WriteLine(e);
    				}
    				Console.WriteLine(result);
    				return result;
    			}
    	}
    }
