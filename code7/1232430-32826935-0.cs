    public class User
    { 
        public User()
        {
            this.Posts = new HashSet<Post>();
        }
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int point {get { return this.Posts.Count*5; } }
        public virtual ICollection<Post> Posts { get; set; }
    }
