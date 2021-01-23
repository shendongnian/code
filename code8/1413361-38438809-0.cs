    public class Anime
    {
        public Anime()
        {
            Description = "This is a desciption";
            DateCreated= DateTime.UtcNow;
           
        }
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }      
        public virtual ICollection<CommentAnime>  Comments { get; set; }
    }
