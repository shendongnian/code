    DataTable dtNew =new DataTable("NewDataTable");
    dtNew.Columns.Add("Date");
    dtNew.Columns.Add("Date1");
    dtNew.Columns.Add("Visits",typeof(int));
    dtNew.Columns.Add("M",typeof(int));
    dtNew.Columns.Add("F",typeof(int));
    dt.AsEnumerable()
      .GroupBy(grp => new
        {
           Date = grp.Field<string>("Date"),
           Date1 = grp.Field<string>("Date1")
        })
       .Select(d =>
           {
             DataRow dr = dtNew.NewRow();
             dr["Date"] = d.Key.Date;
             dr["Date1"] = d.Key.Date1;
             dr["Visits"] = d.Sum(r => r.Field<int>("Visits"));
             dr["M"] = d.Sum(r => r.Field<int>("M"));
             dr["F"] = d.Sum(r => r.Field<int>("F"));
             return dr;
           })
        .CopyToDataTable(dtNew, LoadOption.OverwriteChanges);
