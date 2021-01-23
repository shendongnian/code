    DataTable DT = new DataTable("data");
    DT.Columns.Add("xField", typeof(int));
    DT.Columns.Add("yFields", typeof(int));
    DT.Columns.Add("tipp", typeof(string));
    DT.Columns.Add("kolor", typeof(Color));
    DataRow row = DT.NewRow();
    row["xField"] = 1; row["yFields"] = 1; row["tipp"] = "red"; row["kolor"] = Color.Red;
    DT.Rows.Add(row); // ...etc...
    DataView DV = new DataView(DT);
    chart1.DataSource = DV;
