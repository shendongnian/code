    var result = new List<List<double[]>>();
    
    foreach (var array in listB)
    {
        var ld = new List<double[]>();
        foreach (var index in array)
        {
            ld.Concat(listA[index]);
        }
    
        result.Add(ld);
    }
    
    var indices = listB.SelectMany(arr => arr);
    
    for (int i = 0 i < listA.Length; i++)
    {
        if (indices.Count(i) == 0)
            result.Add(listA[i]);
    }
