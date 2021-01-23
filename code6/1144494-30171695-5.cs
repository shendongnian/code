    var groups = people.GroupBy(v => v.FirstName);
    foreach (var grp in groups)
    {
        var key = grp.Key;
        foreach (var person in grp)
        {
            Debug.WriteLine(person.ToString());
        }
    }
