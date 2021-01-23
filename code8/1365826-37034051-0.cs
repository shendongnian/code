    var collection = from t1 in dataSet.Tables[0].AsEnumerable()
                     join t2 in table2.AsEnumerable()
                     on t1["id"] equals t2["id"]
                     select new
                     {
                         ID = t1["id"],
                         Name = t1["name"],
                         Thing = t2["thing"]
                     };
    DataTable result = new DataTable("Result");
    result.Columns.Add("ID", typeof(string));
    result.Columns.Add("Name", typeof(string));
    result.Columns.Add("Thing", typeof(string));
    foreach (var item in collection)
    {
        result.Rows.Add(item.ID, item.Name, item.Thing);
    }
