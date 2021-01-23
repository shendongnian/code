    namespace CoreProject.Persistence.EFCore
    {
        public partial class User
        {
            public User()
            {
                Reader = new HashSet<Reader>();
                Writer = new HashSet<Writer>();
            }
    
            public int UserId { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string PasswordHashKey { get; set; }
            public byte Role { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime CreatedUtc { get; set; }
            public DateTime LastUpdateUtc { get; set; }
            public byte Status { get; set; }
            public bool Deleted { get; set; }
            public DateTime? ActivatedUtc { get; set; }
            public bool Test { get; set; }
    
            public virtual ICollection<Reader> Reader { get; set; }
            public virtual ICollection<Writer> Writer { get; set; }
        }
    }
