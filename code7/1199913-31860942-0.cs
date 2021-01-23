    var result = Workspace.Prospects.Where(x=> x.NewId == 3)
                      .Join(Workspace.Users.Where(x => x.IsActive == 1),
                              p => p.UserId,
                              u => u.Id,
                              (p, u) => new { p.Id, p.UserId, p.NewId, p.Status })
