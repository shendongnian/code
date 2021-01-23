    IEnumerable<Test> AllChildren(List<Test) list,Test mytest)
    {
      foreach(var test in list)
      {
        if (test.parentid==mytest.id)
        {
           yield return test;
           foreach(var t in AllChildren(list,test))
           {
             yeild return t;
           }
        }
      }
    }
