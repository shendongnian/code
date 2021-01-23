    public class Test
    {
        public Test()
        {
            Title = "this is some text.";
        }
        public string Title { get; set { Title = value; Size = Title.Length; } }
        public Size Size { get; set; }
    }
