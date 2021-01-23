    using System;
    using System.Diagnostics;
    using System.Linq;
    
    namespace Tests
    {
    	class Program
    	{
    		private static void Match(decimal[] inputQty, decimal matchSum, out int[] matchedIndices, out int matchCount, out int operations)
    		{
    			matchedIndices = new int[inputQty.Length];
    			matchCount = 0;
    			operations = 0;
    
    			var nextLessQtyPos = new int[inputQty.Length];
    			for (int i = inputQty.Length - 1; i >= 0; i--)
    			{
    				var currentQty = inputQty[i];
    				int nextPos = i + 1;
    				while (nextPos < inputQty.Length)
    				{
    					var nextQty = inputQty[nextPos];
    					int compare = nextQty.CompareTo(currentQty);
    					if (compare < 0) break;
    					nextPos = nextLessQtyPos[nextPos];
    					if (compare == 0) break;
    				}
    				nextLessQtyPos[i] = nextPos;
    			}
    
    			decimal currentSum = 0;
    			for (int nextPos = 0; ;)
    			{
    				if (nextPos < inputQty.Length)
    				{
    					// Forward
    					operations++;
    					var nextSum = currentSum + inputQty[nextPos];
    					int compare = nextSum.CompareTo(matchSum);
    					if (compare < 0)
    					{
    						matchedIndices[matchCount++] = nextPos;
    						currentSum = nextSum;
    						nextPos++;
    					}
    					else if (compare > 0)
    					{
    						nextPos = nextLessQtyPos[nextPos];
    					}
    					else
    					{
    						// Found
    						matchedIndices[matchCount++] = nextPos;
    						break;
    					}
    				}
    				else
    				{
    					// Backward
    					if (matchCount == 0) break;
    					var lastPos = matchedIndices[--matchCount];
    					currentSum -= inputQty[lastPos];
    					nextPos = lastPos + 1;
    				}
    			}
    		}
    
    		public class MatchSubset
    		{
    			private decimal[] qty = null;
    			private decimal matchSum = 0;
    			public int operations = 0;
    			public int[] matchedIndices = null;
    			public int matchCount = 0;
    			private bool SumUp(int i, int n, decimal sum)
    			{
    				operations++;
    				matchedIndices[matchCount++] = i;
    				sum += qty[i];
    				if (sum == matchSum)
    					return true;
    				if (i >= n - 1)
    				{
    					matchCount--;
    					return false;
    				}
    				if (SumUp(i + 1, n, sum))
    					return true;
    
    				sum -= qty[i];
    				matchCount--;
    				return SumUp(i + 1, n, sum);
    			}
    			public bool Match(decimal[] qty, decimal matchSum)
    			{
    				this.qty = qty;
    				this.matchSum = matchSum;
    				matchCount = 0;
    				matchedIndices = new int[qty.Count()];
    				return SumUp(0, qty.Count(), 0);
    			}
    		}
    
    		static void Main(string[] args)
    		{
    			int maxQtys = 3000;
    			decimal matchQty = 177820;
    			var qty = new decimal[maxQtys];
    			int maxQty = (int)(0.5m * matchQty);
    			var random = new Random();
    			for (int i = 0; i < maxQtys - 2; i++)
    				qty[i] = random.Next(1, maxQty);
    
    			qty[maxQtys - 2] = 99910;
    			qty[maxQtys - 1] = 77910;
    
    			Console.WriteLine("Source: {" + string.Join(", ", qty.Select(v => v.ToString())) + "}");
    			Console.WriteLine("Target: {" + matchQty + "}");
    
    			int[] matchedIndices;
    			int matchCount;
    			int operations;
    			var sw = new Stopwatch();
    
    			Console.Write("#1 processing...");
    			sw.Restart();
    			Match(qty, matchQty, out matchedIndices, out matchCount, out operations);
    			sw.Stop();
    			ShowResult(matchedIndices, matchCount, operations, sw.Elapsed);
    
    			Console.Write("#2 processing...");
    			var match = new MatchSubset();
    			sw.Restart();
    			match.Match(qty, matchQty);
    			sw.Stop();
    			ShowResult(match.matchedIndices, match.matchCount, match.operations, sw.Elapsed);
    
    			Console.Write("Done.");
    			Console.ReadLine();
    		}
    
    		static void ShowResult(int[] matchedIndices, int matchCount, int operations, TimeSpan time)
    		{
    			Console.WriteLine();
    			Console.WriteLine("Time: " + time);
    			Console.WriteLine("Operations: " + operations);
    			if (matchCount == 0)
    				Console.WriteLine("No Match.");
    			else
    				Console.WriteLine("Match: {" + string.Join(", ", Enumerable.Range(0, matchCount).Select(i => matchedIndices[i].ToString())) + "}");
    		}
    	}
    }
