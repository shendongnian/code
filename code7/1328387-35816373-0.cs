    public class User
    {
        public virtual int UserId { get; protected set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime CreateDate { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserRole> Roles { get; set; }
        [InverseProperty("CreateUser")]
        public virtual ICollection<UserRole> CreatedRoles { get; set; }
    }
