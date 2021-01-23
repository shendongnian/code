    public class Test
    {
        public Size Size { get; set; }
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                Size = // calculate size of _title
            }
        }
    }
