    static IEnumerable<int> PrimeNumbers(int numPrimes)
    {
        yield return 2; // first prime number
        for(int n=1, p = 3; n < numPrimes; p+=2)
        {
            if (!checkIfPrime(p)) continue;                                
            n++;
            yield return p;              
        }
    }
    
    // p > 2, odd
    private static bool checkIfPrime(int p)
    {
        for (int t = 3; t <= Math.Sqrt(p); t += 2)
        {
            if (p % t == 0) return false;              
        }
        return true;
    }
