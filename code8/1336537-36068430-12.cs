    var personList = BossList.SelectMany(x => x.Employees).Union(BossList.AsEnumerable()).ToList();
    var ids = personList.Select(x => x.Role == "Manager" ? x.ID : x.SID).Distinct().ToList();
    var result = ids.GroupJoin(personList, id => id, person => person.Role == "Manager" ? person.ID : person.SID,
        (id, persons) => 
        persons.OrderBy(p => p.Role == "Manager" ? 0 : 1).First()).ToList();
