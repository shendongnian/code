	bool hasContinuousDays = false;
	
	var selectedDates = new Dictionary<string, string>();
	selectedDates.Add("2014-06-21", DateTime.Now.ToString());
	selectedDates.Add("2014-06-22", DateTime.Now.AddDays(1).ToString());
	selectedDates.Add("2014-06-23", DateTime.Now.AddDays(2).ToString());
	selectedDates.Add("2014-06-24", DateTime.Now.AddDays(3).ToString());
	
	DateTime lastDay = DateTime.Parse(selectedDates.Values.First());
	hasContinuousDays = selectedDates.Values.Skip(1).All(
			str=> {
					var day = DateTime.Parse(str); 
					var b = day == lastDay.AddDays(1); 
					lastDay = day; 
					return b;
				});
				
	hasContinuousDays .Dump();	
