	var myTimes = new List<WeddingEvent>()
	{
		new WeddingEvent { Id = 1, Reception = DateTime.Now.AddHours(-3) },
		new WeddingEvent { Id = 2, Reception = DateTime.Now.AddHours(-2) },
		new WeddingEvent { Id = 3, Reception = DateTime.Now.AddHours(-1) },
		new WeddingEvent { Id = 4, Reception = DateTime.Now.AddHours(0) },
		new WeddingEvent { Id = 5, Reception = DateTime.Now.AddHours(1) },
		new WeddingEvent { Id = 6, Reception = DateTime.Now.AddHours(2) },
		new WeddingEvent { Id = 7, Reception = DateTime.Now.AddHours(3) },
	};
	DateTime? start = null; //DateTime.Now.AddHours(0.5);
	DateTime? end = DateTime.Now.AddHours(3.5);
	var weddingInHalfAnHour = myTimes.Where(we => (!start.HasValue || start < we.Reception) && (we.Reception < end || !end.HasValue));
	foreach (var wedding in weddingInHalfAnHour)
	{
		Console.WriteLine("Id: {0} ReceptiontTime: {1}", wedding.Id, wedding.Reception);
	}
