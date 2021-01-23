    foreach(var grouping in Model.Items
        .GroupBy(x => new { i.ID, i.DepartmentID })
        .OrderBy(b => b.Key.DepartmentID)
        .ThenBy(t => t.Key.ID))
    {
        Console.WriteLine("{0}, {1}", grouping.Key.DepartmentID, grouping.Key.ID);
        foreach(var item in grouping.OrderBy(n => n.Name))
        {
            Console.WriteLine("\t{0}", item.Name)
        }
    }
