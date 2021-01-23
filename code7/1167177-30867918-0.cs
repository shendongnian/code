        public List<string> GetUserRoles(string username)
        {
            List<string> ListOfRoleNames = new List<string>();
            var ListOfRoleIds = UserManager.FindByName(username).Roles.Select(x => x.RoleId).ToList();
            foreach(string id in ListOfRoleIds)
            {
                string rolename = RoleManager.FindById(id).Name;
                ListOfRoleNames.Add(rolename);
            }
            
            return ListOfRoleNames;
        }
