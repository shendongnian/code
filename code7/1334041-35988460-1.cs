	[HttpPost]
	public async Task DoStuffAsync(string id)
	{
		using (var db = new EstateContext())
		{
			var entity = await _db.Estates.FindAsync(id);
			_db.SaveChanges(); 
		}
	}
	
