      BigInteger value = BigInteger.Pow(2, 3217) - 1; // Mersenne prime number (2.5e968)
    
      Stopwatch sw = new Stopwatch();
    
      sw.Start();
    
      Boolean isPrime = value.IsProbablyPrime(10);
    
      sw.Stop();
    
      Console.Write(isPrime ? "probably prime" : "not prime");
      Console.WriteLine();
      Console.Write(sw.ElapsedMilliseconds);
