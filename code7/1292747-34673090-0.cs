    var results = projects
        .Join(
            units,
            project => project.ProjectNumber,
            unit => unit.ProjectNumber,
            (project, unit) => new ProjectNumberSearchResult
            {
                ProjectNumber = project.ProjectNumber,
                UnitId = unit.UnitId,
                // you can populate any other properties from
                // the view model that you need
            })
        .ToList();
