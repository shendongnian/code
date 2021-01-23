	var heatmap =
		Messages
			.OrderBy(message => (int)message.Timestamp.DayOfWeek)
			.ThenBy(message => message.Timestamp.Hour)
			.GroupBy(message => new { Weekday = (int)message.Timestamp.DayOfWeek, message.Timestamp.Hour })
			.Select(gms => new { gms.Key.Weekday, gms.Key.Hour, Count = gms.Count() });
