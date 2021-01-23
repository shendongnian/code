    using System.Linq;
    using System.Data;
    ....
    var columnHeaders = table.Columns
        .Cast<DataColumn>()
        .Select(x => x.ColumnName)
        .ToArray();
