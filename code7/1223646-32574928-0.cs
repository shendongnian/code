    public bool ValidateUser(string userName, string password)
        {
            var domainUser = _domain.Name + @"\" + userName;
            try
            {
                var user = Business.Authenticate(userName, password);
                if (user == null) return false;
                var scuser = AuthenticationManager.BuildVirtualUser(domainUser, true);
                if (scuser != null)
                {
                    AuthenticationManager.Login(scuser);
                    scuser.RuntimeSettings.AddedRoles.Add(Constants.UserRole);
                    scuser.Profile.SetCustomProperty(Constants.UserEmail, user.Email);
                    scuser.Profile.SetCustomProperty(Constants.UserId, user.UserId);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Diagnostics.Logger.Error(ex.Message);
                return false;
            }
            return false;
        }
