    Dictionary<List<string>, int> newDic = new Dictionary<List<string>, int>();
    newDic.Add(oldSys1.Letters, oldSys1.Points);
    newDic.Add(oldSys2.Letters, oldSys2.Points);
    foreach (KeyValuePair<List<string>, int> oldSysKeyValuePair in newDic)
    {
        //int x = 0; //don't need this
        foreach (var key in oldSysKeyValuePair.Key)
        {
            Console.WriteLine(key + " = " + oldSysKeyValuePair.Value);
        }
     }
