    public class FactorialExample
    {
        public static BigInteger Factorial(int n)
        {
            return Enumerable.Range(2, n).Product();
        }    
    }
    public static class IEnumerableExtensionMethods
    {
        public static BigInteger Product(this IEnumerable<int> multiplicands)
        {
            System.Numerics.BigInteger result = 1;
            foreach (int multiplier in multiplicands)
            {
                result = System.Numerics.BigInteger.Multiply(result, multiplier);
            }
            return result;
        }
    }
