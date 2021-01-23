    SortedSet<string> sorted = new SortedSet<string>();
    for (int i = 0; i < testList.Count; i++)
    {
      if (sorted.Contains(testList[i].TestValue))
        testList[i].IsDuplicate = true;
      else
        sorted.Add(testList[i].TestValue);
    }
