    //select your grouped results
    var retVal = readModel
            .GroupBy("Service", "it")
            .Select("new (it.key as GroupName, Sum(it.NumberOfItems) as GroupItems)");
    
    //Map them
    var res = ((IEnumerable<dynamic>)retVal)
              .Select(x => new GroupView 
                     { 
                        GroupName = x.GroupName, 
                        GroupItems = x.GroupItems 
                     });
