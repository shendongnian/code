    // We do need to hard code that 2 is a prime number. Everything else can be derived
    primes[0] = 2;
    i = 1;
    count = 3;
    // i.e. stop when we get the required number of primes
    while (i < max)
    {
        // Indicator to stop testing this candidate if we find a factor
        bool foundFactor = false;
        // Start off each primality test from the start of our primes array
        var primeIndex = 0;
        // Try and find a factor of 'count' with our known primes
        while (!foundFactor && primeIndex < i)
        {
            // We can stop after the square root. Multiplication is faster than sqrt
            if (primes[primeIndex]*primes[primeIndex] > count)
                break;
            // If the candidate number
            if (count % primes[primeIndex] == 0)
                foundFactor = true;
            primeIndex++;
        }
        if (!foundFactor)
        {
            primes[i] = count;
            i++;
        }
        count++;
    }
