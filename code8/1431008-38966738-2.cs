    var unpivoted = list.SelectMany(i => new[]
    {
        new UnpivotInfo {EmpGuid = i.EmpGuid, Date = i.Birthday, Type = "Birthday", Name = i.Name}
        , new UnpivotInfo {EmpGuid = i.EmpGuid, Date = i.Anniversary, Type = "Anniversary", Name = i.Name}
    });
