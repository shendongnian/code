    List<string> list = new List<string>();
    list.Add("john");
    list.Add("David");
    list.Add("Sam");
    var v = db.employee
        .ToList()
        // This filtering doesn't happen in your SQL server.
        .Where(s => list.Any(x => s.Content.Contains(x)));
