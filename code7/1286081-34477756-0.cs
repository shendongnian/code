    //Order by the projects with Date
    var projectsWithDate = list.Where(d => d.Date != null)
               .OrderBy(s => s.Date).ToList();
    // Projects without Dates
    var withoutdate = list.Where(d => d.Date == null)
        .OrderBy(g =>
        {
            if (g.ImportanceLevel == "High")
                return 1;
            if (g.ImportanceLevel == "Medium")
                return 2;
            if (g.ImportanceLevel == "Low")
                return 3;
            return 0;
        })
        .ToList();
    //Add the second list to first.
    projectsWithDate.AddRange(withoutdate);
