    internal class Program
        {
            private static void Main(string[] args)
            {
                string s = "&someword";
    
                bool ans = HasAmpersandSign("some&word");
    
                Console.WriteLine(ans);
    
                Console.WriteLine(HasAmpersandSignOnly(s));
            }
    
            private static bool HasAmpersandSign(string s)
            {
                return s.Contains("&");
            }
    
            private static bool HasAmpersandSignOnly(string s)
            {
                return s.Contains("&") && s.Length == 1;
            }
        }
