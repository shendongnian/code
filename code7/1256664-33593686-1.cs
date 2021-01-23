    DataTable dtNew =new DataTable("NewDataTable");
    dtNew.Columns.Add("Date");
    dtNew.Columns.Add("Visits",typeof(int));
    dtNew.Columns.Add("M",typeof(int));
    dtNew.Columns.Add("F",typeof(int));
    dt.AsEnumerable().GroupBy(grp => grp.Field<string>("Date")).Select(d => 
                      {
                         DataRow dr = dtNew.NewRow();
                         dr["Date"] = d.Key;
                         dr["Visits"] = d.Sum(r => r.Field<int>("Visits"));
                         dr["M"] = d.Sum(r => r.Field<int>("M"));
                         dr["F"] = d.Sum(r => r.Field<int>("F"));
                         return dr;
                      })
                      .CopyToDataTable(dtNew, LoadOption.OverwriteChanges);
