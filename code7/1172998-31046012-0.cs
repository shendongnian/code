    internal class ExpressionParser
    {
       internal interface IEnumerableSignatures { }
    }
 
    internal static class Extension
    {
        internal static void DefaultIfEmpty(this ExpressionParser.IEnumerableSignatures sig) {
            ...
        }
    }
