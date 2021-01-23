    var logs = (from bwl in db.UserActivities
			where DateTime.Now - Convert.ToDateTime(bwl.Query_Date) <= TimeSpan.FromDays(14)
			select new
			{
				Id = bwl.Id,
				UserEmail = bwl.UserEmail
			}).ToList();
