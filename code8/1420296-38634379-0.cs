    private DataTable dt1;
    protected void Page_Load(object sender, EventArgs e)
    {
       dt1 = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("ShortURL", typeof(int)),
                            new DataColumn("LongURL", typeof(string)),
                            new DataColumn("CreatingDate",typeof(string)) });
                dt.Rows.Add(1, "John Hammond", "United States");
                dt.Rows.Add(2, "Mudassar Khan", "India");
                dt.Rows.Add(3, "Suzanne Mathews", "France");
                dt.Rows.Add(4, "Robert Schidner", "Russia");
    }
