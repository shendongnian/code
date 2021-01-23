     var result = context.Variants
                    .Where(x => x.Type.Equals("Add"))
                    .AsQueryable()
                    .Select(x => new Result
                    {
                            ParentName = x.Name,
                            Type = x.Type,
                            CustomSubvariantList = x.SubVariants                         
                          .SelectMany(a => a.TestOperation)
                          .Where(d=>d.TestId==testId)
                          .Select(z => new CustomSubVariant
                          {
                              SourceId = z.SubVariants.Id,
                              TargetId = z.SubVariants1.Id,
                              Name = z.SubVariants.Name,
                              DiffPerc = z.DiffPerc
                          })
                          .OrderBy(s => s.SourceId)
                          .ToList()
                    }).ToList();
