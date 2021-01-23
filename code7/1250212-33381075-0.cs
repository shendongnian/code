    public partial class Role
    {
        public Role()
        {
            Permissions = new HashSet<Permission>();
        }
    
        [Key]
        public int RoleId { get; set; }
    
        public string RoleName { get; set; }
        public Virtual ICollection<Permission> Permissions { get; set; } //Notice the virtual?!
    }
