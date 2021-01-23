    internal class Program
    {
        private static void Main(string[] args)
        {
            bool ans = HasAmpersandSign("some&word");
            Console.WriteLine(ans);
        }
        private static bool HasAmpersandSign(string s)
        {
            return s.Contains("&");
        }
    }
