	[Flags]
	public enum Permission
	{
		UserManagement = 1,
		DepartmentManagement = 2,
		RoleManagement = 4,
		ModifyPassword = 8
	}
	public class Role
	{
		public string ID { get; set; }
		public string Name { get; set; }
		public Permission Permissions { get; set; }
	}
