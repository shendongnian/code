    // this will get all rows from table two that don't match rows in one
    // the result is an IEnumerable<DataRow> 
    var unmatched = two.AsEnumerable()
      .Except(one.AsEnumerable(), DataRowComparer.Default);
    // CopyToDataTable converts an IEnumerable<DataRow> into a DataTable
    // but it blows up if the source object is empty
    // this statement makes sure unmatched has data before calling CopyToDataTable()
    // if it is empty, we 'clone' (make an empty copy) of one of the original DataTables
    var three = unmatched.Any() ? unmatched.CopyToDataTable() : one.Clone();
