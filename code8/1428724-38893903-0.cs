	List<dynamic> data = new List<dynamic>
	{
		new {ID  = 1, Message = "Hello", GroupId = 1, Date = DateTime.Now},
		new {ID  = 2, Message = "Hello", GroupId = 1, Date = DateTime.Now},
		new {ID  = 3, Message = "Hey",   GroupId = 2, Date = DateTime.Now},
		new {ID  = 4, Message = "Dude",  GroupId = 3, Date = DateTime.Now},
		new {ID  = 5, Message = "Dude",  GroupId = 3, Date = DateTime.Now},
	};
    var result = data.GroupBy(item => item.GroupId)
                     .Select(grouping => grouping.FirstOrDefault())
                     .OrderByDescending(item => item.Date)
                     .ToList();
    //Or you can also do like this:
	var result = data.GroupBy(item => item.GroupId)
					 .SelectMany(grouping => grouping.Take(1))
                     .OrderByDescending(item => item.Date)
					 .ToList();
