	using(DbContext db = new DbContext())
	{
		List<int> settingIdsToRemove = db.Setting
			.Where(m => m.UserId == Uid)
			.Select(m => m.Id)
			.ToList();
		
		foreach(int settingId in settingIdsToRemove)
		{
			Setting settingToRemove = new Setting { Id = settingId };
			db.Entry(settingToRemove).State = EntityState.Deleted;
		}
		
		db.SaveChanges();
	}
