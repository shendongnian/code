        public static void Save<T>(T entity, ISession _session = null, IList<Exception> errors = null) where T : IDomainEntity
        {
			if (_session == null)
			{
				using (var session = OpenEngineSession())
				using (var trans = session.BeginTransaction())
				{
					try
					{
						session.SaveOrUpdate(entity);
						trans.Commit();
					}
					catch (Exception e)
					{
						errors = errors ?? new List<Exception>();
						errors.Add(e);
						trans.Rollback();
					}
				}
			}else
			{
                _session.SaveOrUpdate(entity);
	        }
        }
