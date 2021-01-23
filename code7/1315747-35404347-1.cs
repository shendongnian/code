    var maxValue = list.Values.Max();
	var newList = new string[maxValue];
	Enumerable
		  .Range(0, (int)maxValue)
		  .ToList()
		  .ForEach(x => newList[x] = list.ContainsValue((uint)x) ? x.ToString() : string.Empty);
    // improve memory usage by preventing to create new List in ToList() method
    foreach(var index in Enumerable.Range(0, (int)maxValue))
    {
        newList[index] = list.ContainsValue((uint)index) ? index.ToString() : string.Empty;
    }
