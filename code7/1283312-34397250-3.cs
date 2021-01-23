    partial class News
    {
        public static class Q
        {
            public static Expression<Func<News,bool>> HasPermission(int permissionID)
            {
                return expr => expr.PermissionID == permissionID
            }
         }
     }
