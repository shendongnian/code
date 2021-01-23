    namespace MyNamespace {
      public class MyMembershipProvider : System.Web.Security.MembershipProvider {
        // override at least ApplicationName, CreateUser and ValidateUser 
        // you can throw NotImplementedException for rest
      }
      public class MyRoleProvider : System.Web.Security.RoleProvider {
        // override at least GetAllRoles(), GetRolesForUser() and RoleExists
        // you can throw NotImplementedException for rest
      }
    }
