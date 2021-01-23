    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    // Fill the data tables
    ...
    // Set the primary keys
    dt1.PrimaryKey = new DataColumn[] { dt1.Columns[0] }; // Use the appropriate column index
    dt2.PrimaryKey = new DataColumn[] { dt2.Columns[0] }; // Use the appropriate column index
    // Merge the two data tables in dt1
    dt1.Merge(dt2);
