     DateTime fromDate = new DateTime(2016, 04, 11);
     DateTime toDate = new DateTime(2016, 04, 17);
     var noDayOfList = workers.GroupBy(x=> x.Id)
                              .Where(x =>
                                     x.All(y=> 
                                     y.WorkDate >= fromDate && 
                                     y.WorkDate <= toDate && 
                                     !y.isOff))
                              .Select(z=>z.Key).ToList();   
            
