    public class Test
    {
        private string _title = null;
        private Size _size = null;
        public Test(String title)
        {
            Title = title;
        }
        public string Title { get { return _title; }; set { _title = value; _size = TextRenderer.MeasureText(this.Title, this.Font); } }
        public readonly Size Size { get; }
    }
