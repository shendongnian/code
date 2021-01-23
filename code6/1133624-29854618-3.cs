    public class Test
    {
        private string _title = null;
        private Size _size = null;
        public Test()
        {
            Title = "this is some text.";
        }
        public string Title { get; set { _title = value; _size = _title.Length; } }
        public Size Size { get; }
    }
