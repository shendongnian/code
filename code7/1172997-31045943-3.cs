    internal static class Extension
    {
        internal static int Foo(this ExpressionParser.IEnumerableSignatures b)
        {
            return b.Ib;
        }
    }
    internal class ExpressionParser
    {
        public int Ia { get; set; }
        internal interface IEnumerableSignatures
        {
            int Ib { get; set; }
        }
    }
