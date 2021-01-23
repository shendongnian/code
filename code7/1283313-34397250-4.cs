    public abstract class PermissionBase
    {
       public int PermissionID {get; set;}
    }
    public static class QueryExtensions
    {
       public static Expression<Func<T,bool>> HasPermission<T>(int permissionID) where T: PermissionBase
       {
           return expr => expr.PermissionID == permissionID
       }
    }
