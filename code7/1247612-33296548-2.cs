      var lstRightJoin = (from a in result_two
                                join b in result_one
                                on new { a.Name, a.Class } equals new { b.Name, b.Class }
                                into gj
                                from subpet in gj.DefaultIfEmpty()
                                select new { a.Name, a.Class, Math_Max_Month = (subpet == null ? 0 : subpet.Max_Month), Math_Max = (subpet == null ? 0 : subpet.Max), a.Chem_Max_Month, a.Chem_Max }).ToList();
