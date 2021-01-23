    var dataTable = new DataTable();
    dataTable.Columns.Add("Vehicle", typeof(String));
    foreach (var column in columns)
      dataTable.Columns.Add(column, typeof(Int32));
    foreach (var group in groupedData) {
      var values = new[] { group.Key }
        .Concat(
          columns.Select(
            column => group.Values.ContainsKey(column)
              ? (Object) group.Values[column] : DBNull.Value
          )
        )
        .ToArray();
      dataTable.Rows.Add(values);
    }
