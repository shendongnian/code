     public class TabViewModel
        {
            private readonly Dictionary<string, string> dictionary;
    
            public TabViewModel(Dictionary<string, string> dictionary)
            {
                this.dictionary = dictionary;
            }
    
            public string Header { get; set; }
            public string TextValue {
                get { return this.dictionary[Header]; }
                set { this.dictionary[Header] = value; }}
        }
