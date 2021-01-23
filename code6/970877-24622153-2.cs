    	static DateTime GetLatestHeartBeat(string[] props, string[] vals)
		{
			List<int> heartIndxs = new List<int>();
			// find the indices of "Heart" in parallel
			Parallel.For(0, props.Length,
				index =>
				{
					if (props[index].Contains("Heart"))
					{
						heartIndxs.Add(index);
					}
				});
			// loop over each heart index to find the latest one
			DateTime latestDateTime = new DateTime();
			foreach (int i in heartIndxs)
			{
				DateTime currentDateTime;
				if (DateTime.TryParse(vals[i], out currentDateTime) && (currentDateTime > latestDateTime))
					latestDateTime = currentDateTime;
			}
			return latestDateTime;
		}
