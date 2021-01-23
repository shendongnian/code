            var dictionary = acts.GroupBy(activity => activity.Date.Year) // gives you year-wise groups
                                   .ToDictionary(yearGroup => yearGroup.Key,
                                                 yearGroup => yearGroup.ToDictionary(activity => activity.Date.Month, // gives you month-wise groups
                                                                                     activity => yearGroup.Where(a => a.Date.Month == activity.Date.Month)
                                                                                                          .Select(a => a.Project.ProjectNumber)
                                                                                                          .ToList() // all the project numbers under this year and month
                                                                                    ));
