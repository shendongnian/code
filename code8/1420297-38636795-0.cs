            if (!Page.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("ShortURL", typeof(int)),
                            new DataColumn("LongURL", typeof(string)),
                            new DataColumn("CreatingDate",typeof(string)) });
                dt.Rows.Add(1, "John Hammond", "United States");
                dt.Rows.Add(2, "Mudassar Khan", "India");
                dt.Rows.Add(3, "Suzanne Mathews", "France");
                dt.Rows.Add(4, "Robert Schidner", "Russia");
                ViewState["yourTable"] = dt;
                // or
                Session["yourTable"] = dt;
                // or
                Application["yourTable"] = dt;
            }
        protected void Btn_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.AddRange(new DataColumn[3] { new DataColumn("ShortURL", typeof(int)),
                            new DataColumn("LongURL", typeof(string)),
                            new DataColumn("CreatingDate",typeof(string)) });
            dt2.Rows.Add(1, "John Hammond", "United States");
            dt2.Rows.Add(2, "Mudassar Khan", "India");
            dt2.Rows.Add(3, "Suzanne Mathews", "France");
            dt2.Rows.Add(4, "Robert Schidner", "Russia");
            if (ViewState["yourTable"] != null)
            {
                exportToExcel(ViewState["yourTable"] as DataTable);
            }
            // or
            if (Session["yourTable"] != null)
            {
                exportToExcel(Session["yourTable"] as DataTable);
            }
            // or
            if (Application["yourTable"] != null)
            {
                exportToExcel(Application["yourTable"] as DataTable);
            }
            exportToExcel(dt2);
        }
