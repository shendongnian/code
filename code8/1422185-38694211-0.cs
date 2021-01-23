	var tempData = MonitorsData.MonitorsDataList;
	if (tempData != null)
	{
		foreach (var monitor in tempData)
		{
			foreach (var tehsil in monitor.Tehsils)
			{
				var ordered = tehsil.Schools.OrderBy(x => .Distance).ToList();
				var min = ordered.FirstOrDefault();
				var max = ordered.LastOrDefault();
				ordered.Clear();
				tehsil.Schools.ToList().Add(min);
				tehsil.Schools.ToList().Add(max);
			}
		}
	}
