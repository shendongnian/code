	List<BigInteger> results = new List<BigInteger>();
	Stopwatch sw = new Stopwatch();
	sw.Start();
	for (int i = 0; i < 1000000; i++)
	{
		results.Add(BigInteger.ModPow(new BigInteger(21), 1, new BigInteger(-5)));
	}
	sw.Stop();
	Console.WriteLine($"ModPow took {sw.ElapsedMilliseconds} ms");
	sw.Restart();
	for (int i = 0; i < 1000000; i++)
	{
		results.Add(BigInteger.Remainder(new BigInteger(21), new BigInteger(-5)));
	}
	sw.Stop();
	Console.WriteLine($"Modulus took {sw.ElapsedMilliseconds} ms");
