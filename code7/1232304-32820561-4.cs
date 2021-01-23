    protected void Page_Load(object sender, EventArgs e)
        {
           if (!Page.IsPostBack)
            {
                dtbl = new DataTable();
                dtbl.Columns.Add("id");
                dtbl.Columns.Add("name");
                for (int i = 0; i < 10; i++)
                {
                    DataRow dr = dtbl.NewRow();
                    dr["id"] = i.ToString();
                    dr["name"] = i + 1;
                    dtbl.Rows.Add(dr);
                }
                if (((DataTable)Session["MyDatatable"]).Columns.Count < 0) 
                     { Session["MyDatatable"] = dtbl; }
                else { dtbl = (DataTable)Session["MyDatatable"]; }
            }
        }
