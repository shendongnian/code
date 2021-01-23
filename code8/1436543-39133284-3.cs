    class Program
    {
        static int sides = 3;
        private static int maxPolyNameLength;
        static void Main(string[] args)
        {
            var input = "Triangular Square Pentagonal Hexagonal Heptagonal Octagonal Nonagonal Decagonal Hendecagonal Dodecagonal Tridecagonal Tetradecagonal Pentadecagonal Hexadecagonal Heptadecagonal Octadecagonal Nonadecagonal Icosagonal Icosihenagonal Icosidigonal Icositrigonal Icositetragonal"
                .Split(' ');
            maxPolyNameLength = input.Max(x => x.Length);
            foreach (var s in input)
            {
                PrintDetailLine(s);
                Computing();
                Console.WriteLine();
                sides++;
            }
        }
        static void PrintDetailLine(string polyName)
        {
            Console.Write($"{{0,2}}  {{1,{maxPolyNameLength}}} ", sides, polyName);
        }
        static void Computing()
        {
            double p = 0;
            
            for (var n = 1; n <= 9; n++)
            {
                p = (Math.Pow(n, 2) * (sides - 2) - n * (sides - 4)) / 2;
                Console.Write("{0,3} ", p);
            }
        }
    }
