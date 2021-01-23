    List<int> newList = new List<int>();
    foreach (var item in list.Where(c => newList.Count == 0 || newList.Last() != c))
    {
        newList.Add(item); // 1,2,3,2,1 will add to newList
    }
