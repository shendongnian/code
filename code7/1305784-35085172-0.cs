    var row = dt1.AsEnumerable()
      .Where(x => dt.AsEnumerable()
     .Any(z => z.Field<string>("Email").Trim() == x.Field<string>("Email").Trim())).ToList();//Add ToList() at the end of this query.
    
    DataTable filteredEducation  = row.Any() ? row.CopyToDataTable() : filteredEducation.Clone();
