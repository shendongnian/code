    var results = await dbContext.Nodes.
                            Include(c => c.Parent).
                            Where(c => c.NodeName.Contains(query)).
                            Where(c => c.Children.Any(x => x.NodeName.Contains(query))).
                            OrderBy(n => n.NodeName).
                            ToPagedListAsync(page ?? 1, pageSize);
