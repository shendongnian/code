       public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IList<string> Genre { get; set; } 
        public Rating? Rating { get; set; }
        public int Ranking { get; set; }
    
        public virtual IEnumerable<Actor> Actors { get; set; }
    }
