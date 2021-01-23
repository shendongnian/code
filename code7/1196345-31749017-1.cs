    public class Bar {
        public string a { get; set; }
        public string b { get; set; }
        private string _c = "foo";
        public string c
        {
            get
            {
                return _c;
            }
            set
            {
                _c = value;
            }
        }
    }
