    namespace ConsoleApplication1
    {
        using System.Text.RegularExpressions;
    
        public class Program
        {
            static void Main(string[] args)
            {
                string str = "test=CAPTURE1; test2=CAPTURE2";
    
                var matches = Regex.Matches(str, "(?<Key>[^=]*)=(?<Value>[^;]*)");
    
                string str2 = matches[0].Groups["Key"].Value;
                string str3 = matches[0].Groups["Value"].Value;
            }
        }
    }
