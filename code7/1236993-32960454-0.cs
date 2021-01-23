	public IHttpActionResult TimeDatawithUserandServer(string name, string group)
	{
		var getName = group == "1"
			? (Func<Overalldata, string>)(od => od.Server)
			: (Func<Overalldata, string>)(od => od.User);
		
		var realName = group == "1"
			? name.Replace("-", ".")
			: name;
	
		var UserData = group == "1"
			? db.Overalldatas.Where(x => x.Server == realName)
			: db.Overalldatas.Where(x => x.User == realName);
			
		var groupedData =
			UserData
				.ToArray()
				.GroupBy(x => new { x.EventDate, Name = getName(x) })
				.ToArray();
					
		var res =
			groupedData
				.Select(item => new Model()
				{
					Count = item.Count(),
					Date = item.Key.EventDate.ToString("yyyy-MM-dd HH:mm:ss"),
					Name = item.Key.Name
				})
				.ToList();
			
		return Ok(res);
	}
