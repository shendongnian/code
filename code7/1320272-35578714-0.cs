        /// <summary>
        /// Method to add user to multiple roles
        /// </summary>
        /// <param name="userId">user id</param>
        /// <param name="roles">list of role names</param>
        /// <returns/>
        public Task<IdentityResult> AddToRolesAsync(string userId, ProfileRoles roles)
        {
            return base.AddToRolesAsync(userId, roles.GetStringArray());
        }
