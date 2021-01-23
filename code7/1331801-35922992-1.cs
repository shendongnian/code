	// needs this namespace
	using System.Data.Entity.Migrations;
	public void Update(MyType updateItem)
	{
		if (updateItem != null)
		{
			if (Entities.MyTypes.Any(itm => itm.MyTypeId == updateItem.MyTypeId))
			{
				try
				{
					Entities.Entry(updateItem).State = System.Data.Entity.EntityState.Modified;
				}
				catch
				{
					Entities.Set<MyType>().AddOrUpdate(updateItem);
				}
			}
			else
			{
				Entities.MyTypes.Add(updateItem);
			}
		}
	}
