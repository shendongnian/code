    public Task<UserPrincipal> FindByIdentity (PrincipalContext pc, string username)
        {
            return Task.Run(() =>
            {
                // Do the thing;
            });
        }
