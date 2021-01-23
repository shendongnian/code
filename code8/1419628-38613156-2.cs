    public static class Role
    {
        public const string Admin = "Admin";
        public const string Developer = "Developer";
        public const string Other = "Other";
    }
    . . .
    UserManager.AddToRole(user.Id, Role.Admin);
