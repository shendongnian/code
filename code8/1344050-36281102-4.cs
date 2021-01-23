            var sampleProjectActivities = ProjectActivity.GetProjectActivities();
            var result = sampleProjectActivities.GroupBy(projectActivity => projectActivity.Year)
                .ToDictionary(k => k.Key,
                    v =>
                    {
                        return v.GroupBy(val => val.Month).ToDictionary(a => a.Key, b => b.Select(x => x.ProjectNumber).ToArray());
                          
                    });
