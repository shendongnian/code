    public class User
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        
        [MustBeEmptyToDelete] public virtual ICollection<Post> Posts { get; set; }
        [MustBeEmptyToDelete] public virtual ICollection<File> Files { get; set; }
        // etc...
    }
