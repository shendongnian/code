    public class Blog
    {
        public Blog()
        {
            Posts = new HashSet<Post>();
        }
        
        public int Id { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        //Rest of properties here
    }
    public class Post
    {
        public int Id { get; set; }
        public int? BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        //Reset of properties here
    }
