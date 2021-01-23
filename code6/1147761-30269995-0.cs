		private class Solution
		{
			public int StartIndex;
			public int EndIndex;
			public decimal Sum;
			public int Length
			{
				get { return EndIndex - StartIndex + 1; }
			}
			
		}
		static List<decimal> Solve(List<decimal> elements, decimal target)
		{
			Solution bestSolution = new Solution { StartIndex = 0, EndIndex = -1, Sum = 0 };
			decimal bestError = Math.Abs(target);
			Solution currentSolution = new Solution { StartIndex = 0, Sum = 0 };
			for (int i = 0; i < elements.Count; i++)
			{
				currentSolution.EndIndex = i;
				currentSolution.Sum += elements[i];
				while (elements[currentSolution.StartIndex] <= currentSolution.Sum - target)
				{
					currentSolution.Sum -= elements[currentSolution.StartIndex];
					++currentSolution.StartIndex;
				}
				decimal currentError = Math.Abs(currentSolution.Sum - target);
				if (currentError < bestError || currentError == bestError && currentSolution.Length < bestSolution.Length )
				{
					bestError = currentError;
					bestSolution.Sum = currentSolution.Sum;
					bestSolution.StartIndex = currentSolution.StartIndex;
					bestSolution.EndIndex = currentSolution.EndIndex;
				}
			}
			return elements.GetRange(bestSolution.StartIndex, bestSolution.Length);
		}
