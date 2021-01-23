	try
	{
		db.Add(something);
		db.SaveChanges();
	}
	catch (DbEntityValidationException ex)
	{
		StringBuilder sb = new StringBuilder();
		// collect some extra info about the exception before throwing
		foreach (var eve in ex.EntityValidationErrors)
		{
			sb.AppendLine(String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State));
			foreach (var ve in eve.ValidationErrors)
			{
				sb.AppendLine(String.Format("Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
			}
		}
		logger.Error("There was an error while trying to parse and save something!\n" + sb.ToString(), ex);
	}
