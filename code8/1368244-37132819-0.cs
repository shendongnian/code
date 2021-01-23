    public class ind_dict
    {
        [SQLite.Net.Attributes.PrimaryKey]
        public string id { get; set; }
    
        public string word { get; set; }
        public string translation { get; set; }
    
        public ind_dict()
        {
        }
    
        public ind_dict(string w, string t)
        {
            word = w;
            translation = t;
        }
    }
