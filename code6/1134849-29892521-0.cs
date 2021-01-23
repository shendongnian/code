    public class RoleUserVM
    {
        public IdentityRole Role { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
