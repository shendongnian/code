        public string GetRole(string userId)
        {
            var role = UserManager.GetRoles(userId);
            return role[0];
        }
