    var receivables = new List<Receivable>()
    {
        new Receivable { ReportedOn = DateTime.Now.AddDays(-5), StudentId = 8128, TotalDue = 5.43 },
        new Receivable { ReportedOn = DateTime.Now.AddDays(-4), StudentId = 8128, TotalDue = 4.32 },
        new Receivable { ReportedOn = DateTime.Now.AddDays(-3), StudentId = 8128, TotalDue = 3.21 },
        new Receivable { ReportedOn = DateTime.Now.AddDays(-2), StudentId = 8128, TotalDue = 2.10 },
        new Receivable { ReportedOn = DateTime.Now.AddDays(-1), StudentId = 2818, TotalDue = 1.09 },
        new Receivable { ReportedOn = DateTime.Now, StudentId = 2818, TotalDue = .98 }
    };
         
    var totDue = receivables
        .Where(receivable => receivable.StudentId == 8128)
        .OrderByDescending(receivable => receivable.ReportedOn)
        .Select(receivable => receivable.TotalDue);
    Console.WriteLine("{0}", totDue.First());
