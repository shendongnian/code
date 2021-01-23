    public static Dictionary<int, int> CompareLists(List<int> listA, List<int> listB)
    {
      return listA.FullOuterJoin(listB,
        a=>a,
        b=>b,
        (a,b,key)=>
          new {key=key,value=0},
          new {key=key,value=-1},
          new {key=key,value=1})
        .ToDictionary(a=>a.key,a=>a.value);
    }
