	using (var ctx = new DbCtx) {
		ctx.Database.Connection.Open();
		using (var transaction = ctx.Database.BeginTransaction(IsolationLevel.Serializable))
		{
			try {
				// check + update
				transaction.Commit();
			}
			catch (Exception) {
				transaction.Rollback();
			}
		}
		ctx.Database.Connection.Close();
	}
     
