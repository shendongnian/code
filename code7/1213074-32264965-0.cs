    public static class helper {
    	public static IEnumerable<double> doSomething(this IEnumerable<int> source)
    	{
    		double sum = 0;
    		int count = 0;
    		foreach(var item in source)
    		{
    			sum += item;
    			count++;
    			yield return (sum / count);
    		}
    	}
    }
