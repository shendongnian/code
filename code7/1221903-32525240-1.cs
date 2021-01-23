    private static void RunInTransaction(Action<MyEntities, DbTransaction> action)
	{
		using (var ctx = new MyEntities())
		{
			ctx.Connection.Open();
			using (var tx = ctx.Connection.BeginTransaction())
			{
				action(ctx, tx);
				ctx.SaveChanges();
				tx.Commit();
			}
		}
	}
