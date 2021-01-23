    public class Test
    {
        private string _title;
        public string Title 
        { 
            get { return _title; } 
            set
            {
                _title = value;
                Size = (string.IsNullOrEmpty(value)) ? 0 : Title.Length;
            } 
        }
        public int Size { get; set; }   
    }
