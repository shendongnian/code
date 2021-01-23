    public class Site
    {
        public string Id { get; set; }
    }
    public class AscendingSiteComparer : IComparer<Site>
    {
        // Maybe it's not the best regular expression ever, but if your site
        // ids start with letters either in capital or lower case, it will
        // work!
        private readonly static Regex replaceRegex = new Regex(@"[a-z]+\s*([0-9]+)$", RegexOptions.IgnoreCase);
        public int Compare(Site x, Site y)
        {
            int a = int.Parse(replaceRegex.Replace(x.Id, "$1"));
            int b = int.Parse(replaceRegex.Replace(y.Id, "$1"));
            if (a > b)
                return 1;
            else if (a < b)
                return -1;
            else
                return 0;
        }
    }
