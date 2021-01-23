     class Program
    {
        static void Main(string[] args)
        {
            string text = "#2";
            string pat = @"\#(\w+)";
            Regex r = new Regex(pat);
            Match m = r.Match(text);
            Console.WriteLine(m.Success);
            Console.ReadKey();
        }
    }
