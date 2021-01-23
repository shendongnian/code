    public class Book
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public overrides ToString()
        {
            return this.Title;
        }
    }
