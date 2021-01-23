    public class UserRole : Entity
    {
        public virtual User User { get; set; }
        public RoleEnum Role { get; set; }
    }
