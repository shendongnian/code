      int testId = 100;
                var query =
                      from v in variants
                      where v.Type == "Add"
                      select new
                      {
                          ParentVariant = v.Name,
                          Type = v.Type,
                          CustomSubvariantList =
                           (
                                from sv in subvariants.Select(sv => sv)
                                join x in
                                (
                                     from svparent in v.SubVariants
                                     from to in svparent.TestOperation
                                     where to.TestId == testId
                                     orderby svparent.Id
                                     select new
                                     {
                                         svparent.Name,
                                         to.DiffPerc,
                                         SourceId = to.SubVariants != null ? to.SubVariants.Id : 0,
                                         TargetID = to.SubVariants1 != null ? to.SubVariants1.Id : 0
                                     }
                                 )
                                on sv.Name equals x.Name into g
                                from x in g.DefaultIfEmpty()
                                select new
                                {
                                    SourceId = x == null ? sv.TestOperation.Select(to => to.SourceSubVariantId).First() : x.SourceId,
                                    TargetId = x == null ? sv.TestOperation.Select(to => to.TargetSubVariantId).First() : x.TargetID,
                                    Name = sv.Name,
                                    DiffPerc = x == null ? (decimal?)null : x.DiffPerc
                                }
                             ).Distinct().ToList()
                      };
