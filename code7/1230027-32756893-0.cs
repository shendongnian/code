    var originalList = Enumerable.Range(0, 6).ToList();
      
    var innerArray = (int[])originalList.GetType().GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(originalList);
    var partialList = (IList<int>)new ArraySegment<int>(innerArray, 2, 3);
    
    partialList[0] = -99;
    partialList[1] = 100;
    partialList[2] = 123;
    
    Console.WriteLine(String.Join(", ", originalList));
