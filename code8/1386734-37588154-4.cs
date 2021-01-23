	// Found loaded related entries that can be detached later.
	private HashSet<DbEntityEntry> relatedEntries;
	private DbContext context;
	private List<string> GetPropertiesNames(object classObject)
	{
		// TODO Use cache for that.
		// From question https://stackoverflow.com/questions/5851274/how-to-get-all-names-of-properties-in-an-entity
		var properties = classObject.GetType().GetProperties(BindingFlags.DeclaredOnly |
																  BindingFlags.Public |
																  BindingFlags.Instance);
		return properties.Select(t => t.Name).ToList();
	}
	private void GetRelatedEntriesStart(DbEntityEntry startEntry)
	{
		relatedEntries = new HashSet<DbEntityEntry>();
		// To not process start entry twice.
		relatedEntries.Add(startEntry);
		GetRelatedEntries(startEntry);
	}
	private void GetRelatedEntries(DbEntityEntry entry)
	{
		IEnumerable<string> propertyNames = GetPropertiesNames(entry.Entity);
		foreach (string propertyName in propertyNames)
		{
			DbMemberEntry dbMemberEntry = entry.Member(propertyName);
			DbReferenceEntry dbReferenceEntry = dbMemberEntry as DbReferenceEntry;
			if (dbReferenceEntry != null)
			{
				if (!dbReferenceEntry.IsLoaded)
				{
					continue;
				}
				DbEntityEntry refEntry = context.Entry(dbReferenceEntry.CurrentValue);
				CheckReferenceEntry(refEntry);
			}
			else
			{
				DbCollectionEntry dbCollectionEntry = dbMemberEntry as DbCollectionEntry;
				if (dbCollectionEntry != null && dbCollectionEntry.IsLoaded)
				{
					foreach (object entity in (ICollection)dbCollectionEntry.CurrentValue)
					{
						DbEntityEntry refEntry = context.Entry(entity);
						CheckReferenceEntry(refEntry);
					}
				}
			}
		}
	}
	private void CheckReferenceEntry(DbEntityEntry refEntry)
	{
		// Add refEntry.State check here for your need.
		if (!relatedEntries.Contains(refEntry))
		{
			relatedEntries.Add(refEntry);
			GetRelatedEntries(refEntry);
		}
	}
