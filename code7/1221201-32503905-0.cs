    List<Type> temp = new List<Type>()
    foreach(item in mainList)
    {
       if (item.Delete)
       {
          temp.Add(item);
       }
    }
    
    foreach (var item in temp)
    {
       mainList.Remove(item);
    }
