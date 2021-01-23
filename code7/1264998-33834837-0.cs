    foreach( List<string> i in secondSplitResults )
    {
         if (i.Count == 2)
         {
            i.RemoveAll(x => x.Count == 1 && x[0] == i[0]);
            i.Insert(1,"/");
        }
    }
    PrintResults2(secondSplitResults);
