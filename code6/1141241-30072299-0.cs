    public class Permissions
    {
        public Guid PermissionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<relUserPermissions> relUserPermission {get; set;}
    }
    public class relUserPermissions
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Guid PermissionId { get; set; }
        public Permissions Permission { get; set; }
    }
