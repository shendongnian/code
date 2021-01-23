    var innerList = list.FirstOrDefault();
    if (innerList == null)
    {
        innerList = new List<string>();
        list.Add(innerList);
     }
     innerList.Add("Hussam");
