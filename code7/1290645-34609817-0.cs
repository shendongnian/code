    public class VersionsComparer: IComparer<string>
    {
        public int Compare(string x, string y)
        {
            
            if (x.ToLower() == @"n/a")
            {
                if (y.ToLower() == @"n/a")
                    return 0;
                return -1;
            }
            if (y.ToLower() == @"n/a")
            {
                if (x.ToLower() == @"n/a")
                    return 0;
                return 1;
            }
            
            var verX = Version.Parse(x);
            var verY = Version.Parse(y);
            return verX.CompareTo(verY);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var versions = new[] { "4.5", "2.1", "2.2.1", "7.5", "7.5.3", @"N/A", "2.3.4.5" };
            
            foreach (var v in versions.OrderByDescending(v => v, new VersionsComparer()))
            {
                Console.WriteLine(v);
            }
        }
        
    }
