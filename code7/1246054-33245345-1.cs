    using System;
					
    public class Program
    {
    	public static void Main()
    	{
		    string binary = "";
            double decimalValue = 0;
            Console.WriteLine("Enter in a binary number:");
            binary = Console.ReadLine();
            for (int i = 0; i < binary.Length; i++)
            {
				decimalValue *=2; // shift current value to the left
                if (binary[i] == 49)
				{
                    decimalValue += 1; // add current bit
				}	
                Console.WriteLine("Current value: {0}", decimalValue);
            }
            Console.WriteLine("The decimal equivalent value is {0}", decimalValue);
            Console.ReadLine();
    	}
    }
