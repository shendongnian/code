    var maxWageByDepartment = persons
        .GroupBy(p => p.Department)
        .ToDictionary(g => g.Key, g => g.Max(p => p.Wage));
    var richestPersonByDepartment = persons
        .GroupBy(p => p.Department)
        .Select(g => new { Department = g.Key, HighestEarningPerson = g.First(person => person.Wage == maxWageByDepartment[g.Key]) });
