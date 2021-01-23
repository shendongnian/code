	var heatmap =
		from message in Messages
		let Hour = message.Timestamp.Hour
		let Weekday = (int)message.Timestamp.DayOfWeek
		orderby Weekday, Hour
		group message by new { Weekday, Hour } into gms
		select new { gms.Key.Weekday, gms.Key.Hour, Count = gms.Count() };
