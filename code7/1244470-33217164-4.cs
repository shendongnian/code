	static IEnumerable<T> GetPageItems<T>(List<List<T>> itemLists, int pageSize, int pageIndex)
	{
		int start = pageIndex * pageSize;
		var counts = new int[itemLists.Count];
		for (int i = 0; i < counts.Length; i++)
			counts[i] = itemLists[i].Count;
		Array.Sort(counts);
		int listCount = counts.Length;
		int itemIndex = 0;
		for (int i = 0; i < counts.Length; i++)
		{
			int itemCount = counts[i];
			if (itemIndex < itemCount)
			{
				int rangeLength = listCount * (itemCount - itemIndex);
				if (start < rangeLength) break;
				start -= rangeLength;
				itemIndex = itemCount;
			}
			listCount--;
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
			while (true)
			{
				var list = listQueue[listIndex];
				if (skipCount > 0)
					skipCount--;
				else
				{
					yield return list[itemIndex];
					if (++yieldCount >= pageSize) break;
				}
				if (itemIndex + 1 < list.Count)
				{
					if (nextCount != listIndex)
						listQueue[nextCount] = list;
					nextCount++;
				}
				if (++listIndex < listCount) continue;
				if (nextCount == 0) break;
				itemIndex++;
				listIndex = 0;
				listCount = nextCount;
				nextCount = 0;
			}
		}
	}
