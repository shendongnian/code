    private const int ITERATIONS = 1000000;
    	static void Main(string[] args)
    	{
    		var p = new Test();
    		p.Start();
    	}
    
    	private void Start()
    	{
    		Console.WriteLine();
    		DeterminePrimeAndAddToTotal(1);
    
    		var primes = Enumerable.Range(2, ITERATIONS)
    							   .Select(num => new { Number = num, IsPrime = DeterminePrimeAndAddToTotal(num) })
    							   .Where(value => value.IsPrime);
    
    		var parallelPrimes = Enumerable.Range(2, ITERATIONS)
    									   .AsParallel()
    									   .Select(num => new { Number = num, IsPrime = DeterminePrimeAndAddToTotal(num) })
    									   .Where(value => value.IsPrime);
    		
    		var watch = Stopwatch.StartNew();
		    Console.WriteLine(primes.Count());
		    watch.Stop();
		    var nonParallelTime = watch.ElapsedMilliseconds;
		    watch = Stopwatch.StartNew();
    		Console.WriteLine(parallelPrimes.Count());
    		watch.Stop();
    		var parallelTime = watch.ElapsedMilliseconds;
    
    		Console.WriteLine("parallel/non-parallel");
    		Console.WriteLine(string.Format("{0}/{1}", parallelTime, nonParallelTime));
    	}
    
    	private bool DeterminePrimeAndAddToTotal(long primeOrNot)
    	{
    		bool isPrime = primeOrNot <= 2 || (primeOrNot % 2 != 0);
    
    		long root = (long)Math.Sqrt((long)primeOrNot);
    
    		for (int i = 3; i <= root && isPrime; i += 2) // check only uneven numbers.
    		{
    			if (primeOrNot % i == 0)
    			{
    				isPrime = false;
    			}
    		}
    
    		return isPrime;
    	}
