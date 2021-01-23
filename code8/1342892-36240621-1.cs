	static void AddBirthdayToDictionary(Dictionary<DateTime, List<string>> dict, int month, int day, string name)
	{
	  var bdate = new DateTime(DateTime.MinValue.Year, month, day);
	  List<string> val;
	  if(!dict.TryGetValue(bdate, out val))
	  {
		val = new List<string>();
		dict.Add(bdate, val);
	  }
	  val.Add(name);
	}
	
	static List<string> GetBirthdays(Dictionary<DateTime, List<string>> dict, int month, int day)
	{
	  var bdate = new DateTime(DateTime.MinValue.Year, month, day);
	  List<string> val;
	  if(dict.TryGetValue(bdate, out val))
	  {
		return val;
	  }
	  return new List<string>();
	}
   			   
	static void ShowBirthdays()
	{
		var birthdayDictionary = new Dictionary<DateTime, List<string>>();
		
		// add possible birthdays    
		AddBirthdayToDictionary(birthdayDictionary, 3, 12, "Person 1");
		AddBirthdayToDictionary(birthdayDictionary, 6, 9, "Person 2");
		var today = DateTime.Today;
    	// get birthdays today
		var bdayList = GetBirthdays(birthdayDictionary, today.Month, today.Day);
	
		if(bdayList.Any())
		{
			var count = bdayList.Count();
			MessageBox.Show(string.Format("Hello, today is {0} and {1} {2} celebrating {3} birthday!", today, string.Join(", ", bdayList), (count>1) ? "are":"is", (count>1) ? "their" : "its"));	
		}		
	}
    
    
      
    
     
    
