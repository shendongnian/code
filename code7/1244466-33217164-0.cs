	static IEnumerable<T> GetPageItems<T>(List<List<T>> itemLists, int pageSize, int pageIndex)
	{
		int start = pageIndex * pageSize;
		int itemIndex = 0;
		int listCount = itemLists.Count;
		foreach (var group in itemLists.GroupBy(list => list.Count).OrderBy(group => group.Key))
		{
			int itemCount = group.Key;
			int rangeLength = listCount * (itemCount - itemIndex);
			if (start < rangeLength) break;
			start -= rangeLength;
			itemIndex = itemCount;
			listCount -= group.Count();
		}
		if (listCount > 0)
		{
			var listQueue = new List<T>[listCount];
			listCount = 0;
			foreach (var list in itemLists)
				if (itemIndex < list.Count) listQueue[listCount++] = list;
			itemIndex += start / listCount;
			int listIndex = 0;
			int skipCount = start % listCount;
			int nextCount = 0;
			int yieldCount = 0;
			do
			{
				var list = listQueue[listIndex];
				if (skipCount > 0)
					skipCount--;
				else
				{
					yield return list[itemIndex];
					if (++yieldCount >= pageSize) break;
				}
				if (itemIndex + 1 < list.Count) listQueue[nextCount++] = list;
				if (++listIndex < listCount) continue;
				itemIndex++;
				listIndex = 0;
				listCount = nextCount;
				nextCount = 0;
			}
			while (listCount > 0);
		}
	}
