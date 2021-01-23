    //Create a list of all the dates from your customers
    var dates = new List<DateTime>();
    foreach(var customer in Customers)
    {
        List<DateTime> customerDates = database.GetDates(customer);
        dates.AddRange(customerDates);
    }
    //You can either just take the count of all the dates
    List<int> RegsList = new List<int>();
    var group = dates.GroupBy(d => d)
                     .Select(group => group.Count());
    RegsList.AddRange(group);
    //Or put them in some other collection to know which date has which count
    //for example, a Dictionary
    Dictionary<DateTime, int> OtherRegsList = new Dictionary<DateTime, int>();
    var group2 = dates.GroupBy(d => d)
                     .Select(group => new { Date = group.Key, Count = group.Count() });
    
    foreach(var g in group2)
    {
        OtherRegsList.Add(g.Date, g.Count);
    }
                      
