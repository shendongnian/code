     using (ExtVariablesEntities _varDB = new ExtVariablesEntities())
            {
                // check for UserRoles for this 
                var user = _varDB.Users.FirstOrDefault(x => x.UserName == userDisplayName);
               
                IList<UserRole> usersRoles = new List<UserRole>();
                if (user != null)
                {
                    usersRoles = user.UserRoles.ToList();
                }
                // determine if the user is allowed to see this controller/page
                foreach (var ur in usersRoles)
                {
                    if (groups.Contains(ur.RoleName))
                    {
                        return true;
                    }
                }
            }
