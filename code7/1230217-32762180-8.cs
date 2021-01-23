	void LogEntity<TEntity>(TEntity entity)
	{
		//...log
	}
	void Method(User user)
	{
		LogEntity(context.Set<User>().Remove(user));
	}
