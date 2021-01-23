    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    
    namespace ParsingDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                var matches = Regex.Matches(GetData(), "\".+?\"\\>\\d+\\.\\d+");
    
                foreach (Match m in matches)
                {
                    var key = Regex.Match(m.Value, "\".+?\"");
                    var value = Regex.Match(m.Value, "\\d+\\.\\d+");
    
                    Console.WriteLine("Key is " + key.Value.Trim('"'));
                    Console.WriteLine("Value is " + value.Value);
                }
    
                Console.ReadLine();
            }
    
            static string GetData()
            {
                return
                    "<campoAdicional nombre=\"asdfasdhkjh fdsafhsdfkjh    1s     \">239.220</campoAdicional>" +
                    "<campoAdicional nombre=\"asdfasdhkjh fdsafhsdfkjh    213     \">1229.220</campoAdicional>" +
                    "<campoAdicional nombre=\"asdfasdhkjh fdsafhsdfkjh   fds       \">  9.220</campoAdicional>";
            }
        }
    }
