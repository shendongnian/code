    List<MagicClass> allRoles= new List<MagicClass>();
    
    allRoles= (from roles in context.aspnet_Roles 
              select new MagicClass
              { 
                RoleId = roles.RoleId,
                RoleName = roles.RoleName 
              }).ToList();
    
    public internal class MagicClass
    {
        private string RoleId {get;set;}
        private string RoleName {get;set;}
        
    };
