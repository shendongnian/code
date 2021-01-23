     var model = new EditUserViewModel()
            {
                UserName = user.UserName,
                Email = user.Email,
                IsEnabled = user.IsEnabled,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                UserRole = userRoleName,
                // a list of all roles
                Roles = from r in RoleManager.Roles orderby r.Name select r.Name
            };
