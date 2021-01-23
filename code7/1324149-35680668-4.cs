    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        // Foreign Key
        public string CreatedBy { get; set; }
        // Navigation Property
        public ApplicationUser CreatedByUser { get; set; }
    }
    
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
