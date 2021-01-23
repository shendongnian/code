    IList<object> dataTypeArr = new  List<object> 
    {
        "1.0", 
        "AB", 
        "A",
        DateTime.Now
    };
    
    var typeList2 = new List<object>();
    foreach (var item in dataTypeArr)
    {
        var doubleType = item;
        if (item.ToString().Contains("."))
        {
            doubleType = Convert.ToDouble(item);
            typeList2.Add(doubleType.GetType());
        }
        else
        {
            typeList2.Add(item.GetType());
        }
    }
