    public class TitleAuthorDictionary : Dictionary<string, string>
    {
        public new void Add(string title, string author)
        {
            base.Add(title, author);
        }
    
        public new string this[string title]
        {
            get { return base[title]; }
            set { base[title] = value; }
        }
    }
