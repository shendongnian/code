    var list1 = new List<int>() { 1, 2, 3};
    var list2 = new List<string>() { "Abc", "Def", "Ghi"};
    object[] tempData = new[] { list1.ToList(), list2.ToList() };
    //... user changes something in list1, list2 ...
    list1.Add(12); list1.Remove(3);
    list2.Remove("Def");
    if(cancel)
    {
       list1 = tempData[0] as List<int>;
       list2 = tempData[1] as List<string>; 
    }
