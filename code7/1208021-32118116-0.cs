    public static int Calculate(this IEnumerable<long> input, int minSum, int maxSum)
    {
    	var sortedSet = input.AsParallel().Distinct().OrderBy(n => n).ToArray();
    	for (int lo = 0, hi = sortedSet.Length - 1; lo < hi;)
    	{
    		var sum = sortedSet[lo] + sortedSet[hi];
    		if (sum < minSum) lo++;
    		else if (sum > maxSum) hi--;
    		else return 1 + Calculate(sortedSet, lo, hi, minSum, (int)sum - 1) + Calculate(sortedSet, lo, hi, (int)sum + 1, maxSum);
    	}
    	return 0;
    }
    private static int Calculate(long[] sortedSet, int lo, int hi, int minSum, int maxSum)
    {
    	int count = 0;
    	for (int targetSum = minSum; targetSum <= maxSum; targetSum++)
    	{
    		for (int i = lo, j = hi; i < j;)
    		{
    			var sum = sortedSet[i] + sortedSet[j];
    			if (sum < targetSum) i++;
    			else if (sum > targetSum) j--;
    			else { count++; break; }
    		}
    	}
    	return count;
    }
