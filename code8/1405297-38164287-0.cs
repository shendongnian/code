     List<Project> projectsList =
                    db.Projects.Where(
                        p =>
                            !db.Contracts.Join(db.Applications, c => c.ApplicationId, a => a.ApplicationId,
                                (c, a) => a.ProjectId).Contains(p.ProjectId)).ToList();
