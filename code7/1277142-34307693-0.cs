    public class ForumPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public User Creator { get; set; }
    }
    
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
    }
