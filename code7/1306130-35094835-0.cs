      List<UserRoleViewModel> vmList = new List<UserRoleViewModel>();
            foreach (var userRole in db.UserRoles)
            {
                UserRoleViewModel urVM = new UserRoleViewModel()
                {
                    Name = userRole.RoleName
                };
                if (user.UserRoles.Contains(userRole))
                    urVM.IsChecked = true;
                else
                    urVM.IsChecked = false;
                vmList.Add(urVM);
            }
            model.UserRoles = vmList;
