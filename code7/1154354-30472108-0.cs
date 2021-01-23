    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		int number1 = 2927466;
    		int number2 = 12492771;
    		int number3 = -39284925;
    		
    		Console.WriteLine(OrderDigits(number1, false));
    		Console.WriteLine(OrderDigits(number2, true));
    		Console.WriteLine(OrderDigits(number3, false));
    	}
    	
    	private static int OrderDigits(int number, bool asc)
    	{
    		bool isNegative = number < 0;
    		number = Math.Abs(number);
    		
    		// Extract each digit into an array
    		int[] digits = new int[(int)Math.Floor(Math.Log10(number) + 1)];
    		for (int i = 0; i < digits.Length; i++)
    		{
    			digits[i] = number % 10;
    			number /= 10;
    		}
    		
    		// Order the digits
    		for (int i = 0; i < digits.Length; i++)
    		{
    			for (int j = i + 1; j < digits.Length; j++)
    			{				
    				if ((!asc && digits[j] > digits[i]) ||
    				    (asc && digits[j] < digits[i]))
    				{
    					int temp = digits[i];
    					digits[i] = digits[j];
    					digits[j] = temp;
    				}
    			}
    		}
    
    		// Turn the array of digits back into an integer
    		int result = 0;		
    		for (int i = digits.Length - 1; i >= 0; i--)
    		{
    			result += digits[i] * (int)Math.Pow(10, digits.Length - 1 - i);
    		}
    		
    		return isNegative ? result * -1 : result;
    	}
    }
