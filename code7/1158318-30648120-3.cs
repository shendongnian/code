    public partial class LabRolePermission
    {
        [StringLength(50)]
        public string LabID { get; set; }
        [StringLength(50)]
        public string RoleID { get; set; }
        [StringLength(50)]
        public string PermissionID { get; set; }
        public virtual Lab Lab { get; set; }
        public virtual LabRole LabRole { get; set; }
        public virtual Permission Permission { get; set; }
    }
