    groupedReporting = reporting.GroupBy(r => r.Code)
        .Select(r =>
        {
            var Budget = r.Sum(x => x.BudgetMd);
            var Actuals = r.Sum(x => x.ActualsMd);
            var Delta = 1 - (Budget  - Actuals ) / Budget ;
            
            return new
            {
                r.Code,
                Budget = Budget ,
                Actuals = Actuals ,
                // And the Delta...
                Delta = Delta 
            };
        })
        .OrderBy(r => r.DgId)
        .ToList();
