    var n = new List<Class1>
    {
        new Class1{ Id = 1, Amt =  50 },
        new Class1{ Id = 2, Amt = 500 },
        new Class1{ Id = 1, Amt = 150 },
        new Class1{ Id = 2, Amt = 450 },
        new Class1{ Id = 1, Amt = 250 },
        new Class1{ Id = 2, Amt = 350 },
    };
    var groups = n.GroupBy(x => x.Id);
    foreach (var group in groups.Where(g => g.Count() > 1))
    {
         Console.WriteLine("You have {0} items with ID={1}", group.Count(), group.Key);
    }
