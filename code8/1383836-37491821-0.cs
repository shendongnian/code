    DataTable table = new DataTable();
    table.Columns.Add("employeeid", typeof(int));
    table.Columns.Add("employeeid2", typeof(string));
    table.Rows.Add(null, null);
    table.Rows.Add(100, "50");
    table.Rows.Add(103, "50");
    table.Rows.Add(101, "50");
    table.Rows.Add(102, "52");
    // This is if the column employeeid is a nullable value type
    var distinctCount = table.Rows.OfType<DataRow>().DistinctBy(x => x["employeeid"]).Count(x => x["employeeid"] != null);
    // This is if the column employeeid is a string type
    var distinctCount2 = table.Rows.OfType<DataRow>().DistinctBy(x => x["employeeid2"]).Count(x => !string.IsNullOrWhiteSpace(x["employeeid2"].ToString()));
