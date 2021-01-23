	[HttpPost]
	public async Task DoStuffAsync(string id)
	{
		var entity = await _db.Estates.FindAsync(id);
		_db.SaveChanges(); 
	}
