    var query= from f in context.Form.Include(f=>f.Sections.Select(s=>s.Questions))
               where f.Id == *some form id*
               select
                      new
                         {
                            Root = f,
                            Sections = f.Sections
                                        .OrderBy(s => s.SortOrder)
                                        .Select(s=> new{s.Id, s.SortOrder, Questions=s.Questions.OrderBy(q=>q.SortOrder)})
                         };
