    using System.Numerics;
    ...
    int n = 95;
    
    BigInteger factorial = Enumerable
      .Range(1, n)
      .Select(x => (BigInteger) x)
      .Aggregate((f, v) => f * v);
    
    Console.WriteLine(factorial);
