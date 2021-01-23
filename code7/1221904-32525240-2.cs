    private static T RunInTransactionAndReturn<T>(
        Func<MyEntities, DbTransaction, T> function)
	{
		using (var ctx = new MyEntities())
		{
			ctx.Connection.Open();
			using (var tx = ctx.Connection.BeginTransaction())
			{
				var result = function(ctx, tx);
				ctx.SaveChanges();
				tx.Commit();
                return result;
			}
		}
	}
