    public static class Extension
    {
       public static string GetRoleList(this List<Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole> roles)
       {
          string rolelist="";
          if(roles.Count==0)
             return "None";
          foreach (var item in roles)
          {
             rolelist+=item+",";
          }
          return rolelist.TrimEnd(',');
       }
    }
