    public class Roles
    {
     [Key]
     public string RoleId {get;set;}
     public string RoleName {get;set;}
     public List<Roles> Roleslist { get;set; }  //Take a list in Model as shown
    }
