    public class Site
    {
        public string Id { get; set; }
    }
    public class SiteComparer : IComparer<Site>
    {
        public int Compare(Site x, Site y)
        {
            return string.Compare(x.Id.Replace(" ", string.Empty), y.Id.Replace(" ", string.Empty), StringComparison.OrdinalIgnoreCase);
        }
    }
