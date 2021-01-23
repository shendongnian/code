    var loadValues = (from c in ctx.CValues
                        where c.Company == comp
                        select c).ToLookup(x => Tuple.Create(x.CompanyId, x.ID), 
                                            x => x.ComboValue);
    
    foreach (var item in data)
    {
        // your same code goes here 
        // then
    
       if (designation != 0)
          mod.DesignationString = loadValues[Tuple.Create(comp, designation)].FirstOrDefault();
       if (department != 0)
          mod.DepartmentString = loadValues[Tuple.Create(comp, department)].FirstOrDefault();
    
        list.Add(mod);
    }
