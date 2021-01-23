     int testId = 1;
                using (var context = new VariantsEntities())
                {
                    var query =
                     (from v in context.Variants
                      where v.Type == "Add"
                      select new
                      {
                          ParentVariant = v.Name,
                          Type = v.Type,
                          CustomSubvariantList =
                          (
                                from sv in context.SubVariants.Select(sv => sv)
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
                                         SourceId = (int?)to.SubVariants.Id ?? 0,
                                         TargetID = (int?)to.SubVariants1.Id ?? 0
                                     }
                                 )
                                on sv.Name equals x.Name into g
                                from x in g.DefaultIfEmpty()
                                select new
                                {
                                    SourceId = (int?)x.SourceId ?? sv.TestOperation.Select(to => to.SourceSubVariantId).FirstOrDefault(),
                                    TargetId = (int?)x.TargetID ?? sv.TestOperation.Select(to => to.TargetSubVariantId).FirstOrDefault(),
                                    Name = sv.Name,
                                    DiffPerc = x.DiffPerc
                                }
                             ).Distinct()
                      });
    
                    foreach (var item in query)
                    {
                        Console.WriteLine($"Type: {item.Type} - ParentVariant: {item.ParentVariant} ");
                        foreach (var csubvar in item.CustomSubvariantList)
                            Console.WriteLine($"SourceId: {csubvar.SourceId} - TargetiId: {csubvar.TargetId} - NAme: {csubvar.Name} - DiffPerc: {csubvar.DiffPerc} ");
                    }
