    var firstDataTable = dt1.AsEnumerable()
      .Where(x => dt.AsEnumerable()
     .Any(z => z.Field<string>("Email").Trim() == x.Field<string>("Email").Trim()));
    
    DataTable filteredEducation  = new DataTable();
    
    if(firstDataTable.Any())
    {
        filteredEducation  = firstDataTable.CopyToDataTable();
    }
