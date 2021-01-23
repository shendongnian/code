    public class Results
    {
        public string url { get; set; }
        public string title { get; set; }
        public override bool Equals(object obj)
        {
            Results other = obj as Results;
            if (other == null)
                return false;
            return other.url == this.url && other.title == this.title;
        }
        public override int GetHashCode()
        {
            return new {url, title}.GetHashCode();
        }
    }
