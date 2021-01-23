    public class Test
    {
        public string Title { get; set; }
        private Size _size;
        public readonly Size Size 
        { 
            get
            {
                _size = TextRenderer.MeasureText(this.Title, this.Font);
            } 
        }
    }
