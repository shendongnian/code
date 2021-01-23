    for (var i = 0; i < 10; i++)
    {
        var summary = new CustomerSummary { ID = i, Name = "foo", balance = 50.00 };
    
        if (!summaries.Any(s=> s.ID == summary.ID))
            summaries.Add(summary);
    }
