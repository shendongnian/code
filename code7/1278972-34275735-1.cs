    IList<object> dataTypeArr = new  List<object> 
    {
        1.0, 
        "AB", 
        "A",
        DateTime.Now
    };
    
    var typeList2 = new List<object>();
    foreach (var item in dataTypeArr)
    {
        typeList2.Add(item.GetType());
    }
