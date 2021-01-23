    List<string> list = new List<string>();
    list.Add("john");
    list.Add("David");
    list.Add("Sam");
    var v = db.employee.Where(s => list.Contains(s.Content)).ToList();
