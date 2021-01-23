    using System.Numerics;
    using System.Linq;
    public static IEnumerable<BigInteger> Fibonacci() {
      BigInteger a = 0;
      BigInteger b = 1;
      yield return a;
      yield return b;
      while (true) {
        BigInteger result = a + b;
        a = b;
        b = result;
        yield return result;
      }
    }
