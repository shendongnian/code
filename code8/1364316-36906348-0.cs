    var result = List<int>();
    foreach(var item in integers)
    {
        if(!result.Any())
        {
            result.Add(item);
        }
        else if(result[result.Count() - 1] != item)
        {
            result.Add(item);
        }
    }
