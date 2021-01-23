	int primesCount = 10;
	List<uint> primes = new List<uint>() { 2u };
	for (uint n = 3u;; n += 2u)
	{
		if (primes.TakeWhile(u => u * u <= n).All(u => n % u != 0))
		{
			primes.Add(n);
		}
		if (primes.Count() >= primesCount)
		{
			break;
		}
	}
