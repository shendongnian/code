	void OnTagsReported(ImpinjReader sender, TagReport report)
	{
		List<Tag> tags = report.ToList();
	
		var lists =
			new [] { "A", "B", "C", "D", "E", }
				.Select(c =>
					tags
						.Where(tag => tag.Epc.ToString().IndexOf(c) != -1)
						.ToList())
				.ToList();
	
		foreach (var list in lists)
		{
			list.RemoveAll(tag =>
			{
				Impinj.OctaneSdk.ImpinjTimestamp second = tag.LastSeenTime;
				string milisecondsUTC = second.ToString();
				long lastseen = Convert.ToInt64(milisecondsUTC);
				TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
				long secondsSinceEpoch = (long)t.TotalMilliseconds;
				return secondsSinceEpoch - lastseen > 5000;
	        });
		}
	
		SetText(lists.Select(list => list.Count()).ToArray());
	}
