	public class User{
		public Guid UserId {get;set;}
		public Role Role {get;set;}
		public Association Association {get;set;}
	}
	
	public class Role{
		public Guid RoleId {get;set;}
	}
	
	public class Association{
		public Guid AssociationId {get;set;}
	}
