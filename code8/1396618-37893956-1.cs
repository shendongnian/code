    protected void Page_Load(object sender, EventArgs e)
    {
    If(!IsPostBack)
    {
        string query = "USE db_compiler SELECT Column_Name FROM tbl_field WHERE Table_Name='deptt'";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
    
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
    
                DataTable table = new DataTable();
                adp.Fill(dt);
    
                Session["num"] = dt.Rows.Count;
    
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataColumn dc = new DataColumn(dt.Rows[i]["Name"].ToString());
                    table.Columns.Add(dc); // Make this Column in 2nd DataTable and bind that to Gridview
                }
                DataRow r = table.NewRow();
                Session["table"] = dt;
                table.Rows.Add(r); // Add as many row you want to add  with for loop
                Gridview1.DataSource = table;
                Gridview1.DataBind();
    
    }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                TextBox txt = new TextBox();
                e.Row.Cells[i].Controls.Add(txt);
            }
        }
    }
