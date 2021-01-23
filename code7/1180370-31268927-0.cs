    protected void Page_Load(object sender, EventArgs e)
    {
       DataTable dt = new DataTable();
       DataColumn dc = new DataColumn();
       if (dt.Columns.Count == 0)
       {
           dt.Columns.Add("Produktgruppe", typeof(string));
           dt.Columns.Add("Produkt", typeof(string));
           dt.Columns.Add("Jan", typeof(string));
           dt.Columns.Add("Feb", typeof(string));
           dt.Columns.Add("March", typeof(string));
           dt.Columns.Add("may", typeof(string));
           dt.Columns.Add("Jun", typeof(string));
       }
       DataRow NewRow = dt.NewRow();
       NewRow[0] = " ";
       NewRow[1] = "Anzahl";
       dt.Rows.Add(NewRow); 
       GridView1.DataSource = dt;
       GridViewl.DataBind();
    }
