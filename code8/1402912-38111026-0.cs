	var oldestDate = DateTime.Now.AddDays(-14); 
	var dateString = oldestDate.ToString(*/ your date format */);
	var oldestID = db.UserActivities.First(b => b.Query_Date == dateString).Id;
	var logs = (from bwl in db.UserActivities
				where bwl.Id > oldestID
				select new {
					Id = bwl.Id,
					UserEmail = bwl.UserEmail
				}).ToList();
