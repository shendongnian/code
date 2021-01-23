    public static IdentityResult AddToRole<TUser, TKey>(
	this UserManager<TUser, TKey> manager,
	TKey userId,
	RoleId role
    )
    where TUser : class, Object, IUser<TKey>
    where TKey : Object, IEquatable<TKey>
    {
        return manager.AddToRoleAsync(userId, role.ToString())
                      .Result;
    }
