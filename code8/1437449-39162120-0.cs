    var newRows = tableold.AsEnumerable().Where(r => !values.Contains(r.Field<string>("Dosage")));
    if(newRows.Any())
        tableold = newRows.CopyToDataTable();
    else
        tableold = tableold.Clone(); // empty
