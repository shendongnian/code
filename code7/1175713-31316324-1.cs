    UserPrincipal user_locked = UserPrincipal.FindByIdentity(ctx, username);
	if (user_locked != null) {
		if (user_locked.IsAccountLockedOut()){
           user_locked.UnlockAccount();											
		}
		user_locked.Dispose();
		Console.WriteLine("Unlocked");
	}
	ctx.Dispose();
