    class FakeSecurity : ISecurity
    {
        public bool CurrentUserHasPermission;
        public List<string> RequestedPermissions = new List<string>();
        public bool UserHasPermission(string permission)
        {
            this.RequestedPermissions.Add(permission);
            return this.CurrentUserHasPermission;
        }
    }
