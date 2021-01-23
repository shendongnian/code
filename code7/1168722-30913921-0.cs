    var aColLookup= myDataTable.AsEnumerable().ToLookup(row => row.Field<int>("a"));
    DataTable trueTable = myDataTable.Clone();
    DataTable falseTable = myDataTable.Clone();
    if(aColLookup[1].Any())
        trueTable = aColLookup[1].CopyToDataTable();
    if (aColLookup[0].Any())
        falseTable = aColLookup[0].CopyToDataTable();
