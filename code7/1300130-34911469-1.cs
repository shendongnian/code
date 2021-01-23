    public class IntTypeTraits : ITypeTraits<int> {
        public int Add(int a, int b) { return a+b; }
        public int Mul(int a, int b) { return a*b; }
    }
    public class LongTypeTraits : ITypeTraits<long> {
        public long Add(long a, long b) { return a+b; }
        public long Mul(long a, long b) { return a*b; }
    }
    ... // and so on
