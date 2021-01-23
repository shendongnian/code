    public List<Consumer> GetAllCustomers()
    {
        NorthwindDataContext dc = new NorthwindDataContext();
        List<Consumer> results = new List<Consumer>();
        Consumer consumer = new Consumer();
        foreach (Output_Master cust in dc.Output_Masters)
        {
            results.Add(new Consumer()
            {
               Record_ID = cust.Record_ID,
     MeterCycle = cust.MeterCycle,
     Agency = cust.Agency,
     WorkDate =cust.WorkDate
         });
    }
    ///examble
    results = results.Where(i => i.Record_ID == "1").ToList(); 
    return results;
    }
