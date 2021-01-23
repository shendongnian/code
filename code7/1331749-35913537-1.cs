 	public class User_Role
	{
		public int UserID { get; set; }
		public string Role { get; set; }
		public string UserName { get; set; }
		public virtual Site Site { get; set; }
	}
