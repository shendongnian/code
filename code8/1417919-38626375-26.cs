     var result = from x in db.Variants
                select new PageViewModel
                {
                    ParentVariant = x.Name,
                    Type = x.Type,
                    CustomSubvariantList = (from z in db.SubVariants.GroupBy(g => g.Name)
                        .Select(g => g.FirstOrDefault(d => d.VariantId == x.Id) ?? g.FirstOrDefault())
                        let testOpTarget = z.TestOperations1
                            .FirstOrDefault(q => q.TargetSubVariantId == z.Id)
                        let testOpSource = z.TestOperations
                            .FirstOrDefault(q => q.SourceSubVariantId == z.Id)
                        select new Customsubvariantlist
                        {
                            Name = z.Name,
                            SubVariantId = z.Id,
                            CombineName =(z.TestOperations.Any() || z.TestOperations1.Any())? 
                                          testOpTarget.TargetValue.HasValue? 
                                          testOpTarget.SubVariant.Name+" to "+testOpTarget.SubVariant1.Name : null: "Undefined",
                            Value = x.Id == z.VariantId
                                ? testOpTarget.TargetValue ??
                                  testOpSource.SourceValue
                                : null,
                            DiffPerc = x.Id == z.VariantId
                                ? testOpTarget.DiffPerc
                                : null
                        }).OrderBy(k => k.SubVariantId).ToList()
                };
