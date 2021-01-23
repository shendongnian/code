        public class GroupBaseModel
    {
        public int GroupId { get; set; }
        public int GroupName { get; set; }
    }
    public class RoleBaseModel
    {
        public int RoleId { get; set; }
        public int RoleName { get; set; }
    }
    public class GroupMemberModel : GroupBaseModel
    {
        public bool IsMember { get; set; }
    }
    public class GroupRoleBaseModel : GroupBaseModel
    {
        public int RoleId { get; set; }
        public int RoleName { get; set; }
    }
