    namespace ConsoleApplication2
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			PrimeNumbers(100);
    		}
    		
    		public string PrimeNumbers(int n)
    		{
    			string result = n.ToString();
    			try
    			{
    				for (int i = 2; i < n; i++)
    				{
    					int rest = n % i;
    					if (rest == 0)
    					{
    						resultado = n + "isn't a prime number";
    						i = n + 1;
    					}
    					else
    					{
    						resultado = n + "it's a prime number";
    					}
    				}
    			}
    			catch (Exception e)
    			{
    				Console.WriteLine("Error checking prime number");
    				Console.WriteLine(e);
    			}
    			Console.WriteLine(result);
    			Console.Read();
    			return result;
    		}
    	}
    }
