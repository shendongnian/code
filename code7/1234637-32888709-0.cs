	public static void Main()
	{
		var source = new List<ListItem>();
		source.Add(new ListItem { Title = "ItemTitle" });
		source.Add(new ListItem { Title = "ItemTitle_v2" });
		source.Add(new ListItem { Title = "ItemTitle_v3" });
		source.Add(new ListItem { Title = "OtherTitle" });
		
		var target = new List<ListItem>();
		target = source;
		
		foreach(var item in source)
		{
			if(item.Title == "ItemTitle")
			{
				var newTitle = GetItemTitle(target, "ItemTitle");
				Console.WriteLine(newTitle);
			}
		}
	}
	
	private static string GetItemTitle(IList<ListItem> destList, string titleToCheck)
	{
		int verNum;
		
		// Get the last added item with matching title
		var match = destList.Last(s => s.Title.StartsWith(titleToCheck));
		
		// Check if there are items with versioned title
		if(match.Title.ToLower().Contains("_v"))
		{
			// Get the version string
			string verStr = match.Title.Split('_')[1];
			// Get the version number
			string verNo = verStr.ToLower().Replace("v", string.Empty);
			if(int.TryParse(verNo, out verNum))
			{
				verNum++;
			}
		}
		else
		{
			verNum = 2;
		}
		return string.Format("{0}_v{1}", titleToCheck, verNum);
	}
