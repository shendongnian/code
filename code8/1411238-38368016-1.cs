      int count = 1000;
      List<long> primes = new List<long>() {
        2 }; // <- the only even prime
      for (long value = 3; primes.Count < count; value += 2) {
        long n = (long) (Math.Sqrt(value) + 0.1);
        foreach (var i in primes)
          if (i > n) {
            primes.Add(value);
            break;
          }
          else if (value % i == 0)
            break;
      }
      // 3682913
      Console.WriteLine(string.Format("{0}", primes.Sum()));
      Console.ReadLine();
