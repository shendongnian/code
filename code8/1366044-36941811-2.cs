	public class Utilities
	{
        // Int Input -------------------------------------------
        public int inInt(string input)
        {
            int int_in; 
			try 
			{ 
				int_in = Int32.Parse(intput); 
			}
            catch (FormatException) 
			{ 
				Console.WriteLine("Input Error \b"); 
				int_in = 0; 
			}
            catch (OverflowException) 
			{ 
				Console.WriteLine("Input Owerflow\b"); 
				int_in = 0; 
			}
            return int_in;
        }
        // Float Input -------------------------------------------
        public float inFloat(string input)
        {
            ... etc
        }
	
	}
