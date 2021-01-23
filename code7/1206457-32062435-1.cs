     /// <summary>
        /// Add a user to a role
        /// 
        /// </summary>
        /// <param name="userId"/><param name="role"/>
        /// <returns/>
        public virtual async Task<IdentityResult> AddToRoleAsync(TKey userId, string role)
        {
          this.ThrowIfDisposed();
          IUserRoleStore<TUser, TKey> userRoleStore = this.GetUserRoleStore();
          TUser user = await TaskExtensions.WithCurrentCulture<TUser>(this.FindByIdAsync(userId));
          if ((object) user == null)
            throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Resources.UserIdNotFound, new object[1]
            {
              (object) userId
            }));
          IList<string> userRoles = await TaskExtensions.WithCurrentCulture<IList<string>>(userRoleStore.GetRolesAsync(user));
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
            await TaskExtensions.WithCurrentCulture(userRoleStore.AddToRoleAsync(user, role));
            identityResult = await TaskExtensions.WithCurrentCulture<IdentityResult>(this.UpdateAsync(user));
          }
          return identityResult;
        }
