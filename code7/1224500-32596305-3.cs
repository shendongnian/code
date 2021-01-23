    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Samples
    {
    	class Sample
    	{
    		static void Main(string[] args)
    		{
    			int matchSum = 20; // int.Parse(Console.ReadLine());
    			int[] numbers = { 5, 1, 3, 2, 5, 1, 8, 7, 4 }; // Console.ReadLine().Split().Select(int.Parse).ToArray();
    
    			Array.Sort(numbers);
    			var stack = new Stack<int>();
    			int matchCount = 0, currentSum = 0, nextPos = 0;
    			while (true)
    			{
    				// Next
    				for (int nextSum; nextPos < numbers.Length; currentSum = nextSum, nextPos++)
    				{
    					nextSum = currentSum + numbers[nextPos];
    					if (nextSum > matchSum) break;
    					stack.Push(nextPos);
    					if (nextSum < matchSum) continue;
    					matchCount++;
    					Console.WriteLine("{0} = {1}", matchSum, string.Join(" + ", stack.Reverse().Select(pos => numbers[pos])));
    					stack.Pop();
    					break;
    				}
    				// Back
    				if (stack.Count == 0) break;
    				var lastPos = stack.Pop();
    				var lastNumber = numbers[lastPos];
    				currentSum -= lastNumber;
    				nextPos = lastPos + 1;
    				while (nextPos < numbers.Length && numbers[nextPos] == lastNumber)
    					nextPos++;
    			}
    			if (matchCount == 0)
    			{
    				Console.WriteLine("No matching subsets.");
    			}
    			Console.ReadLine();
    		}
    	}
    }
