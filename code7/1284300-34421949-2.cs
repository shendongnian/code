    var rootObj = JsonConvert.DeserializeObject<JArray>(jsonArray).ToObject<List<RootObject>>().Where(x => 
                     x.Assignees != null &&
                     x.Assignees.Any(y => y.ID == "3333" && y.IsPrimaryOffice == true))
              .FirstOrDefault();
    foreach (var assignee in rootObj.Assignees)
	{
			Console.WriteLine("ID = " + assignee.ID);
		    	Console.WriteLine("IsPrimaryOffice = " + assignee.IsPrimaryOffice);
	}
