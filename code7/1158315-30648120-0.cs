    public partial class LabRole
    {
        public LabRole()
        {
            LabRolePermissions = new HashSet<LabRolePermission>();
            LabUserRoles = new HashSet<LabUserRole>();
            RoleSubscriptions = new HashSet<RoleSubscription>();
        }
        [StringLength(50)]
        public string RoleID { get; set; }
        [StringLength(50)]
        public string LabID { get; set; }
        public virtual ICollection<LabRolePermission> LabRolePermissions { get; set; }
        public virtual Lab Lab { get; set; }
        public virtual ICollection<LabUserRole> LabUserRoles { get; set; }
        public virtual ICollection<RoleSubscription> RoleSubscriptions { get; set; }
    }
