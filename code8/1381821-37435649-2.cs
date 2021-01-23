	public void PublishItem(Database dbMaster, Database dbWeb, Item iParent)
	{
		try
		{
			PublishOptions po = new PublishOptions(dbMaster, dbWeb, PublishMode.SingleItem, Sitecore.Context.Language, DateTime.Now);
			po.RootItem = iParent;
			po.Deep = true; // Publishing subitems
			(new Publisher(po)).Publish();
		}
		catch (Exception ex)
		{
			Sitecore.Diagnostics.Log.Error("Exception publishing items from custom pipeline! : " + ex, this);
		}
	}
