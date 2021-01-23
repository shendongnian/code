    var groups = n.GroupBy(x => x.Id);
    foreach (var group in groups.Where(g => g.Count() > 1))
    {
          Console.WriteLine("You have {0} items with ID={1}", group.Count(), group.Key);
    }
