    public class book
    {
        public string science { get; set; }
        public string math { get; set; }
        public string drawing { get; set; }
        public string english { get; set; }
        public book()
        {
        }
        public void CopyTo(book other)
        {
            if (!string.IsNullOrEmpty(this.science))
                other.science = this.science;
            if (!string.IsNullOrEmpty(this.math))
                other.math = this.math;
            if (!string.IsNullOrEmpty(this.drawing))
                other.drawing = this.drawing;
            if (!string.IsNullOrEmpty(this.english))
                other.english = this.english;
        }
    }
