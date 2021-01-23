    public class StringAscendingComparer : IComparer<string>
    {
        private readonly static Regex replaceRegex = new Regex(@"[a-z]+\s*([0-9]+)$", RegexOptions.IgnoreCase);
    
        public int Compare(string x, string y)
        {
    
            int a = int.Parse(replaceRegex.Replace(x, "$1"));
            int b = int.Parse(replaceRegex.Replace(y, "$1"));
    
            if (a > b)
                return 1;
            else if (a < b)
                return -1;
            else
                return 0;
        }
    }
    var orderedSites2 = sites.OrderBy(site => site.Id, new StringAscendingComparer());
