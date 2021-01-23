    public class CommentsAnime
    {
        public int Id { get; set; }
        public int AnimeId { get; set; } //Using the virtual table name
        public string Opinion { get; private set; }
        public int Mark { get; private set; }
        public virtual Anime Anime { get; set; }
    }
