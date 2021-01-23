    var query=from p in DataContext.Project 
              join c in DataContext.Subscriptions on p.ProjectId equals c.ProjectId into subs
              select new ProjectViewModel { 
                                            ProjectId = p.ProjectId,
                                            Name = p.Name,
                                            Subscriptions=subs.ToList()
                                          };
