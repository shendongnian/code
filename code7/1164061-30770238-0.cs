    // Add a reference to System.Data.DataSetExtensions
    // Query the headerTransaction table to select all items with TransactionID == 1, as an example, use your own value(s)
    IEnumerable<DataRow> query =
    from headers in headerTransaction.AsEnumerable()
    where order.Field<int>("TransactionID") = 1
    select order;
    // Create a table from the query. AsEnumerable() returns IEnumerable<DataRow>. As you asked for a DataTable, we convert IEnumerable<DataRow> to a DataTable, using CopyToDataTable().
    DataTable headersIdQuery = query.CopyToDataTable<DataRow>();
