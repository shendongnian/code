    var columns = new Dictionary<string, string> {
        ["EN"] = "Name",
        ["SU"] = "Super",
        ["DT"] = "Deran",
        ["PR"] = "PRate"
    };
    var filters = from ddl in Controls.OfType<DropDownList>()
                  where ddl.SelectedIndex > 0 && columns.ContainsKey(ddl.ID)
                  select new {
                      Column = columns[ddl.ID], 
                      Value = ViewState[ddl.ID].ToString()
                  };
    var query = dtTest.AsEnumerable();
    foreach(var fitler in filters)
       query = query.Where(r => r.Field<string>(fitler.Column) == fitler.Value);
    DataTable selectedTable = query.CopyToDataTable();
