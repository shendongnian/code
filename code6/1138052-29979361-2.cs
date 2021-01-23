    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		Calc.Reduce(2,4);
    		Calc.Reduce(2,-4);
    	}
    }
    
    public static class Calc
    {
    	public static int gcd(int answerNumerator, int answerDenominator)
    	{
    		// assigned x and y to the answer Numerator/Denominator, as well as an  
    		// empty integer, this is to make code more simple and easier to read
    		int x = Math.Abs(answerNumerator);
    		int y = Math.Abs(answerDenominator);
    		int m;
    		// check if numerator is greater than the denominator, 
    		// make m equal to denominator if so
    		if (x > y)
    			m = y;
    		else
    			// if not, make m equal to the numerator
    			m = x;
    		// assign i to equal to m, make sure if i is greater
    		// than or equal to 1, then take away from it
    		for (int i = m; i >= 1; i--)
    		{
    			if (x % i == 0 && y % i == 0)
    			{
    				//return the value of i
    				return i;
    			}
    		}
    
    		return 1;
    	}
    
    	public static void Reduce(int answerNumerator, int answerDenominator)
    	{
    		Console.Write("Initial: ");
    		WriteFraction(answerNumerator, answerDenominator);
    		
    		try
    		{
    			//assign an integer to the gcd value
    			int gcdNum = gcd(answerNumerator, answerDenominator);
    			if (gcdNum != 0)
    			{
    				answerNumerator = answerNumerator / gcdNum;
    				answerDenominator = answerDenominator / gcdNum;
    			}
    
    			if (answerDenominator < 0)
    			{
    				answerDenominator = answerDenominator * -1;
    				answerNumerator = answerNumerator * -1;
    			}
    		}
    		catch (Exception exp)
    		{
    			// display the following error message 
    			// if the fraction cannot be reduced
    			throw new InvalidOperationException("Cannot reduce Fraction: " + exp.Message);
    		}
    		
    		Console.Write("Reduced: ");
    		WriteFraction(answerNumerator, answerDenominator);
    		Console.WriteLine("---");
    	}
    	
    	public static void WriteFraction(int answerNumerator, int answerDenominator)
    	{
    		Console.WriteLine(string.Format("{0}/{1}", answerNumerator, answerDenominator));
    	}
    }
