    context.PatientTable.GroupBy(a => a.LivingSpace.Name, a => 1)
        .Select(a => new 
            {
                a.Key, 
                Total = a.Sum(q => q) 
            })
        .Union(PatientTable.Select(a => new 
            { 
                Key = "Total", 
                Total = PatientTable.Count() 
            }))
