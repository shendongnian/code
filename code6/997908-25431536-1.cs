    using System.Linq;
    using System.Text;
    using System.Diagnostics.Contracts;
    public class Foo {
        public static string ParallelReplace (string text, char[] fromc, char[] toc) {
            Contract.Requires(text != null);
            Contract.Requires(fromc != null);
            Contract.Requires(toc != null)
            Contract.Requires(fromc.Length == toc.Length);
            Contract.Ensures(Contract.Result<string>().Length == text.Length);
            Array.Sort(fromc,toc);
            StringBuilder sb = new StringBuilder();
            foreach(char c in text) {
                int i = Array.BinarySearch(fromc,c);
                if(i >= 0) {
                    sb.Append(toc[i]);
                } else {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    
    }
