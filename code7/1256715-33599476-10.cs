    public class RoleStatus
    {
        public string Role { get; set; }
        public bool IsUserInRole { get; set; }
    }
    public class RoleStatusUserModel
    {
        public List<RoleStatus> RoleStatuses { get; set; }
        public string UserName { get; set; }
    }
