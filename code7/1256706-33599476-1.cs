    [Route("UpdateRoles")]
        public AdminAccountGenericResponse UpdateRoles(RoleStatusUserModel model)
        {
            ValidateRequestHeader(Request);
            if (!Authorize(Context, Request, new string[] { "Administrators" }))
                throw new ApplicationException("Not Authorized");
            var roles = Roles.GetAllRoles();
            //MembershipUser user = Membership.GetUser(model.UserName);
            foreach (string role in roles)
            {
                RoleStatus roleStat = model.RoleStatuses.FirstOrDefault(rs => rs.Role == role);
                if (roleStat != null)
                {
                    if (roleStat.IsUserInRole == true && !Roles.IsUserInRole(model.UserName, role))
                    {
                        Roles.AddUserToRole(model.UserName, role);
                    }
                    else if (roleStat.IsUserInRole == false && Roles.IsUserInRole(model.UserName, role))
                    {
                        Roles.RemoveUserFromRole(model.UserName, role);
                    }
                    else
                    { }
                }
                else
                {
                    return new AdminAccountGenericResponse
                    {
                        Success = false,
                        Message = "",
                        Error = "Role is null."
                    };
                }
            }
            return new AdminAccountGenericResponse
            {
                Success = true,
                Message = "Role created",
                Error = ""
            };
        }
