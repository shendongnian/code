    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine(SubscriptNums("C6H12O6"));
    	}
    	
    	
    	public static string SubscriptNums(string input)
    	{		
    		char[] replacementChars = { '₀', '₁', '₂', '₃', '₄', '₅', '₆', '₇', '₈', '₉' };
    		
    		int zeroCharIndex = (int)'0';
    		
    		char[] inputCharArray = input.ToCharArray();
    		
    		for(int i = 0; i < inputCharArray.Length; i++)
    		{
    			if (Char.IsDigit(inputCharArray[i]))
    			{
    				inputCharArray[i] = replacementChars[(int)inputCharArray[i] - zeroCharIndex];
    			}
    		}
    		
    		return new string(inputCharArray);
    	}
    }
