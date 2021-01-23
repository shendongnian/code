	public static void ClearChanges(this DataServiceContext context)
	{
		foreach (var entity in context.Entities.ToList())
		{
			context.Detach(entity.Entity);
		}
		foreach (var link in context.Links.ToList())
		{
			context.DetachLink(link.Source, link.SourceProperty, link.Target);
		}
	}
