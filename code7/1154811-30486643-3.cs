    var tree = db.Categories.Include(ct => ct.Groups.Select(gr =>
                                              gr.Types.Select(pr => 
                                                 pr.Products)))               
               .Where(c => c.Groups.Any(g => 
                             g.Types.Any(t => 
                               t.Items.Any(i => 
                                 i.Color == "blue"))))
               .Select(c => new { Groups = c.Groups.Where(g => 
                                             g.Types.Any(t => 
                                               t.Items.Any(i => 
                                                 i.Color == "blue"))
                                  .Select( g => new { Types = g.Types.Where(t => 
                                               t.Items.Any(i => 
                                                 i.Color == "blue"))
                                                      .Select(t => new { Items = t.Items.Where(i => 
                                                                                   i.Color == "blue")
               .ToList() // Return list of anonymous types (
