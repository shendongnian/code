    var subPaths = GetSubPaths("1/2/10/4").ToList();
    for(int i = 0; i < subPaths.Count; i++)
    {
        Console.Write("i = " + i + "; ");
        Console.WriteLine(subPaths[i]);
    }
