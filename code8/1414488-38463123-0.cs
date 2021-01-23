    var query = cb.MakeModelYear;
    
    if (chkYear.Checked)
        query = query.Where(i => i.Year != null);
    if (chkMake.Checked)
        query = query.Where(i => i.Make != null);
    if (chkModel.Checked)
        query = query.Where(i => i.Model != null);
    var uniquecombos = query.Distinct().ToList();
