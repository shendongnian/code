    public static class RtContract
    {
        [Pure] [ContractAbbreviator] [Conditional("MYPROJECT_CONTRACTS_RUNTIME")]
        public static void Requires(bool condition)
        {
            Contract.Requires(condition);
        }
        [Pure] [ContractAbbreviator] [Conditional("MYPROJECT_CONTRACTS_RUNTIME")]
        public static void Ensures(bool condition)
        {
            Contract.Ensures(condition);
        }
        [Pure] [Conditional("MYPROJECT_CONTRACTS_RUNTIME")]
        public static void Assume(bool condition)
        {
            Contract.Assume(condition);
        }
    }
    public class Usage
    {
       void Test (int x)
       {
            Contract.Requires(x >= 0);  // for static and runtime
            RtContract.Requires(x.IsFibonacci());  // for runtime only
       }
    }
