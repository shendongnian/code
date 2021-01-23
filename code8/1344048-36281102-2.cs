        var sampleProjectActivities = ProjectActivity.GetProjectActivities();
        var result = sampleProjectActivities.GroupBy(projectActivity => projectActivity.Year)
            .ToDictionary(k => k.Key,
                v =>
                {
                    return v.ToList()
                        .GroupBy(val => val.Month)
                        .ToDictionary(a => a.Key, b => b.ToList().Select(x => x.ProjectNumber).ToArray());
                });
