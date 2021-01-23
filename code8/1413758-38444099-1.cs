    List<int> list = Enumerable.Range(0, 20).ToList();
    List<int> indexesToRemove = new List<int>(){ 5, 13, 18 };
    
    foreach(int i in indexesToRemove.OrderByDescending(x => x))
    {
        list.RemoveAt(i);
    }
