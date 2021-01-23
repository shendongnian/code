        /// <summary>
        /// Method to add user to multiple roles
        /// </summary>
        /// <param name="userId">user id</param>
        /// <param name="roles">list of role names</param>
        /// <returns/>
        public Task<IdentityResult> AddToRolesAsync(string userId, string[] roles)
        {
            return yourrolestore.AddToRolesAsync(userId, roles.GetStringArray());
        }
