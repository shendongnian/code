    public class Showing
    {
        public string MovieName { get; set; }
        [ForeignKye("MovieName")]
        public virtual Movie Movie { get; set; }
    }
