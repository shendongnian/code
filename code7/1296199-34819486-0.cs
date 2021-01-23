     public partial class User
    {
        public User()
        {
        }
    
        public long Id { get; set; }
        public bool Active { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime Created { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime? Updated { get; set; }
        public string Username { get; set; }
        public long? UserTypeId { get; set; }
    
        public virtual List<Address> Addresses { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Post> Posts { get; set; }
        public virtual UserType UserType { get; set; }
    }
