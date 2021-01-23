	public static IQueryable<DataReturn> WhereIsOwnedByUser(this IQueryable<DataReturn> set, User user)
	{
		return set.Where(
			ret =>
				ret.Entity.Id == user.Entity.Id
				&&
				UserOwnsTemplate(user, ret.Request.Template)
		)
		.InlineFunctions();
	}
