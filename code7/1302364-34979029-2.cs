    var sw = new StreamWriter(@"ABC.txt");
    try
    {        
        var AList = new List<AStruct>();
        
        var locker = new object();
        Parallel.For(0, 10, i =>                          // generate 10 AStruct(s)
        {
            lock (locker) { AList.Add(new AStruct()); }
        });
    
        var sb = new StringBuilder();
        for (int i = 0; i < AList.Count; i++)             //put in a StringBuilder
        {
            sb.AppendLine(AList[i].ToString());
        }
        sw.Write(sb.ToString());
    } finally
    {
        sw.Close();
    }
