    public class PagesIndexedInBing
    {
    }
    public class Backlink
    {
        public string anchor_text { get; set; }
        public string source_url { get; set; }
        public string found_on { get; set; }
        public object page_authority { get; set; }
        public int link_strength { get; set; }
        public string domain { get; set; }
        public int domain_authority { get; set; }
    }
    public class __invalid_type__12222
    {
        public PagesIndexedInBing pages_indexed_in_bing { get; set; }
        public object download_time { get; set; }
        public List<Backlink> backlinks { get; set; }
    }
    public class Site
    {
        public __invalid_type__12222 __invalid_name__12222 { get; set; }
    }
    public class __invalid_type__10555
    {
        public List<Site> sites { get; set; }
    }
    public class Account
    {
        public __invalid_type__10555 __invalid_name__10555 { get; set; }
    }
    public class RootObject
    {
        public List<Account> accounts { get; set; }
    }
