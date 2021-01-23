    Var getData = new List < ParentViewModel > ();
    
    
    getData = (from objtbl1 in ParentTable
               select new ParentViewModel
               {
                proty1 = objtbl1 .proty1,
                childViewModelProprt = (from objChildtbl1 in childTable
                                       select new ChildViewModel
                                       {
                                            childPrty1 = objChildtbl1.childPrty1
                                        }).toList()
               }).toList();
    
    return getData;
