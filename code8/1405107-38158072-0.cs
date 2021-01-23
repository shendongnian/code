                var query = (from cat in category
                             join v in variants on cat.Id equals v.CategoryId
                             //join sv in subVariants on v.Id equals sv.VariantId
                             //join to in context.TestOperation on sv.Id equals to.SourceSubVariantId
                             //join tod in context.TestOperationDifference on sv.Id equals tod.SourceSubVariantId
                             into grp select grp).ToList();
                             //where 
                             // (to.DiffPerc < 100) 
                             //    ||
                             // (tod.DiffPerc < 100 )
                             //group cat by new { catid = cat.Id } into grp
                             //select grp).ToList();
                  // .Select(x => new {
                  //  subcategoryname= x.Key,                 
                  //  //ParentCategoryName=grp.
                  //  //FinalAverage=    
                  //}).ToList();
