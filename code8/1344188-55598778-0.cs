        public void AddUserToGroup(string userId, int groupId)
        {
            Group group = _db.Groups.Find(groupId);
            User user = _db.Users.Find(userId);
            var userGroup = new UserGroup
            {
                Group = group,
                GroupId = group.Id,
                User = user,
                UserId = user.Id
            };
            
            #region turning off Alphanumeric since we are using email in username
            var db = new DBModel();
            DBModel context = new DBModel();
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            userManager.UserValidator = new UserValidator<User>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
            #endregion
            foreach (RoleGroup role in group.Roles)
            {
                var test = userManager.AddToRole(userId, role.Role.Name);
            }
            user.Groups.Add(userGroup);
            _db.SaveChanges();
        }
