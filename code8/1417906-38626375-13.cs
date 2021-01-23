         var result = context.Variants
                        .Where(x => x.Type.Equals("Add"))
                        .ToList()                
                        .Select(x => new Result
       {
         ParentName = x.Name,
         Type = x.Type,
         CustomSubvariantList=context.TestOperations 
             .GetCustomSubVariantsList()
             .OrderBy(x=>x.SourceId)
             .ToList()
        }).ToList();
       public static class MethodExt
        {
            public static List<CustomSubVariant> GetCustomSubVariantList(this IQueryable<TestOperation> source)
            {
                var testOps = source.Select(z => new CustomSubVariant
                {
                    SourceId = z.SourceSubVariantId,
                    TargetId = z.TargetSubVariantId,
                    Name = z.SubVariants.Name,
                    DiffPerc = z.DiffPerc
                }).ToList();
    
                var testOps1 = source.Select(z => new CustomSubVariant
                {
                    SourceId = z.SourceSubVariantId,
                    TargetId = z.TargetSubVariantId,
                    Name = z.SubVariants1.Name,
                    DiffPerc = z.DiffPerc
                }).ToList();
    
                testOps.AddRange(testOps1);
                return testOps.GroupBy(x => x.Name).Select(x => x.First()).ToList();
            }
        }
