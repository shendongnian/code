    public class BlogPost
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int AuthorId { get; set; }
        public Dictionary<string, object> ToDictionary()
        {
            return this.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(this, null));
        }
    }
