    List<CustomerSummary> summaries = new List<CustomerSummary>();
    for (var i = 0; i < 10; i++)
    {
        var summary = new CustomerSummary { ID = 1, Name = "foo", balance = 50.00 };
    
        summaries.Add(summary);
    }
