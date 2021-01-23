	public IQueryable<IGrouping<T, LogEntry>> GetLogEntries<T>(
			MyDataEntities context, 
			IQueryable<T> entities, 
			Expression<Func<T, LogKey>> outerKeySelector
		)
	{
		// Join:
		var query = 
			entities.Join(
				context.auditLogSet,
				outerKeySelector,
				log => new LogKey { TableName = log.TableName, EntityId = log.EntityId },
				(ent, log) => new { entity = ent, log = log }
			);
		
		// Grouping:
		var group = 
			from pair in query
			group pair.log by pair.entity into grp
			select grp;
		
		return group;
	}
