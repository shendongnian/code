    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		const int MAX_LOTTO_NUMBERS = 6;
    		
    		Random r = new Random();
    		List<int> lotteryNumbers = new List<int>();
    		
    		while (lotteryNumbers.Count < MAX_LOTTO_NUMBERS)
    		{
    			int lottoNumber = r.Next(1, 41); // Generate random number from 1 - 40
    			if (!lotteryNumbers.Contains(lottoNumber))
    			{
    				lotteryNumbers.Add(lottoNumber);
    			}
    		}
    		
    		Console.WriteLine(String.Join(", ", lotteryNumbers.ToArray()));
    	}
    }
