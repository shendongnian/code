	var items = new []
	{
		new MyObj() { Date = null },
		new MyObj() { Date = null },
		new MyObj() { Date = DateTime.Now },
	};
	
	var grouped = items.GroupBy(x => x.Date);
