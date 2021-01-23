	var count = db.Model.Count();
	for(int i = 0; i < count; i++)
	{
		var model = db.Model.ElementAt(i);
		model.ID = i;
	}
	db.SaveChanges();
