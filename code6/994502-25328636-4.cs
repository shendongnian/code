    public virtual async Task<IdentityResult> AddToRoleAsync(TKey userId, string role)
    {
        // sanity checks... 
        IList<string> userRoles = await userRoleStore.GetRolesAsync(user).ConfigureAwait(false);
        IdentityResult identityResult;
        if (userRoles.Contains(role))
        {
          identityResult = new IdentityResult(new string[1]
          {
            Resources.UserAlreadyInRole
          });
        }
        else
        {
        // actually add user to role
        }
        return identityResult;
    }
