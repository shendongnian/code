	[HttpPost]
	public async Task DoStuffAsync(string id)
	{
		using (var db = new EstateContext())
		{
			var entity = await db.Estates.FindAsync(id);
			db.SaveChanges(); 
		}
	}
	
