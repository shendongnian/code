    var permissions = new List<Permission>(){ 
                      new Permission (){
                                          Id= 1, 
                                          Name = "Test1"
                                       }, 
                      new Permission{     Id = 2, 
                                          Name = "Test2"}
    };
	var applicationRoles = new List<ApplicationRole>(){
                           new ApplicationRole{ 
                                                Id =1, 
                                                PermissionId = 2
        }};
    var x = from p in permissions
			join ar in applicationRoles on p.Id equals ar.PermissionId
			select p;
    public class Permission{
	public byte Id {get;set;}
	public string Name {get;set;}
	
	public List<ApplicationRole> Roles {get;set;}
    }
    public class ApplicationRole {
	public byte Id {get;set;}	
	public byte PermissionId {get;set;}
    }
