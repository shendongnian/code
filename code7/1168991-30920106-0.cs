    var result =(from a in _applicationRepository.GetList(a => a.ID == applicationId)
                          from r in _roleRepository.GetList(r => r.ApplicationId == a.ID && r.Name == rolename)
                          from au in _authorizationRepository.GetList(au => au.ApplicationId == a.ID && r.ID == au.RoleId)
                          from u in _userRepository.GetList(u => u.ID == au.UserId && u.UserPrincipalName == username)
                          where a.EnableApplication == true && a.EnableAuthorization == true && a.EnableRoles == true && a.ID == applicationId
                          //select 1, or a, or anything, it doesn't really mind
                          select 1).Any();
