    var resultList = groupedBillSitesThatExceed
            .AsEnumerable() //Query will be completed here and loaded from sql to memory
            // From here we could use any of our class or methods
            .Select(x => new ElectricityBillSiteExceeding
            {
                //Map your properties here
            })
            .ToList(); //Only if you want List instead IEnumerable
    return resultList;
