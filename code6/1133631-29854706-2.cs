    public class Test
    {
        public string Title { get; set; }
        public readonly Size Size 
        { 
            get
            {
                return TextRenderer.MeasureText(this.Title, this.Font);
            } 
        }
    }
