    public class OrganizationUnitMember
    {
        public int OrganizationUnitMemberId { get; set; }
        public int UserId { get; set; }
        public int OrganizationUnitId { get; set; }
        [ForeignKey("UserId")]
        public virtual OmegaUser User { get; set; }
        [ForeignKey("OrganizationUnitId")]
        public virtual OrganizationUnit OrganizationUnit { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual OrganizationRole Role { get; set; }
    }
