	string array = "2015-10-23 13:00"; 
	var date = DateTime.Parse(array);
	var Timespan = date - DateTime.Now;
	Console.WriteLine(Timespan.ToString(@"hh\:mm\:ss"));
	Console.WriteLine(string.Format("{0} hours {1} minutes {2} seconds", Timespan.Hours, Timespan.Minutes, Timespan.Seconds));
	Console.WriteLine(string.Format("{0} minutes {1} seconds", (int)Timespan.TotalMinutes, Timespan.Seconds));
