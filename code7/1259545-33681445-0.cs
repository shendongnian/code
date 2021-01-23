    var joined = oldDt.AsEnumerable().Join(newDt.AsEnumerable(), dr => dr.Field<int>("CustomerId"), dr => dr.Field<int>("CustomerId"), (da, db) => Tuple.Create(da, db)).ToList();
    var differences = new List<Difference>();
    foreach (var entry in joined) {
        var customerId = entry.Item1.Field<int>("CustomerId");
        foreach (var column in oldDt.Columns.Cast<DataColumn>()) {
            var oldVal = entry.Item1[column.ColumnName];
            var newVal = entry.Item2[column.ColumnName];
            if (!object.Equals(oldVal, newVal)) {
                differences.Add(new Difference { CustomerId = customerId, FieldName = column.ColumnName, OldDataRowValue = Convert.ToString(oldVal), NewDataRowValue = Convert.ToString(newVal) });
            }
        }
    }
