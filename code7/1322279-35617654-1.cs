    var newList = new List<MyClass>[oldList.GetLength(0), oldList.GetLength(1)];
    for (int i = 0; i < oldList.GetLength(0); i++)
        for (int j = 0; j < oldList.GetLength(1); j++)
            newList[i, j] = oldList[i, j].Select(x => new MyClass(x)).ToList();
                
