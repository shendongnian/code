     var result = context.Variants
                    .Where(x => x.Type.Equals("Add"))
                    .ToList()                
                    .Select(x => new Result
                    {
                            ParentName = x.Name,
                            Type = x.Type,
                            CustomSubvariantList = context.SubVariants                         
                          .SelectMany(a => a.TestOperation)
                          .GroupBy(a=>a.SubVariants.Name) //group by subvariant nameand take first from each group
                          .SelectMany(x=>x.First())
                          .Where(d=>d.TestId==testId)
                          .Select(z => new CustomSubVariant
                          {
                               SourceId = z.SourceSubVariantId,
                               TargetId = z.TargetSubVariantId,
                              Name = z.SubVariants.Name,
                              DiffPerc = z.DiffPerc
                          })
                          .OrderBy(s => s.SourceId)
                          .ToList()
                    }).ToList();
