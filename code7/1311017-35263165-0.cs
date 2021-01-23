    public class User
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<File> Files { get; set; }
        // etc...
        public bool CanDelete()
        {
            return !Posts.Any() &&
                   !Files.Any(); // &&
                   // etc... 
        }
    }
