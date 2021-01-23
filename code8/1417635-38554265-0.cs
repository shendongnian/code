    private static uint[] mersennePrimes = new uint[] { 3, 7, 31, 127, 8191, 131071, 524287, 2147483647 };
    public static bool IsMersenePrime(uint value)
    {
    	return mersennePrimes.Contains(value);
    }
