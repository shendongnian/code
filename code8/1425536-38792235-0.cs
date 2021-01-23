    private static DataTable CombineHostnames(DataTable dtOrginal)
    {
        DataTable tblresult = dtOrginal.Clone(); // empty table, same columns
        var rowGroups = dtOrginal.AsEnumerable()
            .GroupBy(row => new
            {
                Id = row.Field<int>("testId"),
                passFail = row.Field<string>("passFail")
            });
        foreach (var group in rowGroups)
        {
            DataRow row = tblresult.Rows.Add(); // already added now
            row.SetField("testId", group.Key.Id);
            row.SetField("passFail", group.Key.passFail);
            row.SetField("description ", group.First()["description"]);  // the first?
            string hostNames = String.Join(", ", group.Select(r => r.Field<string>("hostname")));
            row.SetField("hostname", hostNames);
        }
        return tblresult;
    }
