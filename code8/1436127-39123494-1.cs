        public UserModel GetUsers()
        {
           var allUsers = context.Users.Include("Roles").ToList();
           var model = new UserModel
             {
                Users = allUsers.Select(x => new OverWatchUser
                {
                    Email = x.Email,
                    EmailConfirmed = x.EmailConfirmed,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    OrgId = x.OrgId,
                    Role = GetRole(x.Id)
                }).ToList()
            };
            return model;
        }
