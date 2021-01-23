    public static IEnumerable<T> GetLevel<T>(IEnumerable<Person> persons, 
        Func<Person, Tuple<string, string, string>> group)
        where T : OrgUnit, new()
    {
        var level1 = persons.Where(x => 
            !string.IsNullOrEmpty(group(x).Item2 == null ? group(x).Item1 :
            (group(x).Item3 ?? group(x).Item2)))
            .GroupBy(group)
            .Select(ac => new T
            {
                Org0 = ac.Key.Item1,
                Org1 = ac.Key.Item2,
                Org2 = ac.Key.Item3,
                Consultants = ac.Count(x => x.EmpGroup.Equals("Consultant")),
                Employees = ac.Count(x => x.EmpGroup.Equals("Employee"))
            });
        return level1;
    }
