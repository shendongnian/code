    Dictionary<string, List<TestValue>> myList = new Dictionary<string, List<TestValue>>();
    while(NotEndOfData())
    {
         TestValue obj = GetTestValue();
         if(myList.ContainsKey(obj.Name))
         {
             obj.IsDuplicate = true;
             myList[obj.Name].Add(obj);
         }
         else
         {
             obj.IsDuplicate = false;
             myList.Add(obj.Name, new List<TestValue>() { obj};
         }
    }
