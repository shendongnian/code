     DateTime fromDate = new DateTime(2016, 04, 11);
     DateTime toDate = new DateTime(2016, 04, 17);
     var noDayOfList = workers.Where(x => 
                               x.WorkDate >= fromDate && 
                               x.WorkDate < toDate && 
                               x.isOff == false).ToList();  
            
