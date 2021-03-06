        //Test clocks at 137ms
		public static Dictionary<string, string> FullPathBuilderImproved(IEnumerable<string> partialPathList, IEnumerable<string> fullPathList)
		{
			Dictionary<string, string> result = new Dictionary<string, string>();
			partialPathList = partialPathList.OrderBy(s => string.Concat(s.Reverse()));
			List<string> unmatchedList = fullPathList.OrderBy(s =>string.Concat(s.Reverse())).ToList();
			foreach (string partPath in partialPathList)
			{
				string matchedFullPath = unmatchedList.FirstOrDefault(f => f.EndsWith(partPath));
				if (matchedFullPath != null)
				{
					result.Add(partPath, matchedFullPath);
					unmatchedList.Remove(matchedFullPath);
				}
				else
				{
					result.Add(partPath, partPath);
				}
			}
			return result;
		}
