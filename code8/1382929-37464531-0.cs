    void MarkDuplicates()
    {
        testList = testList.OrderBy(f => f.TestValue).ThenBy(f => f.SortOrder).ToList();
        for (int i = 1; i < testList.Count; i++) 
        {
            if (testList[i].TestValue == testList[i - 1].TestValue) testList[i].IsDuplicate = true;
        }
        testList = testList.OrderBy(f => f.SortOrder).ToList();
    }
