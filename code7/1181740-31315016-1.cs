    protected void Page_Load(object sender, EventArgs e)
    {
       if (!Page.IsPostback)
          {
             DataTable dt = new DataTable();
             ViewState.Add("dt", dt);
          }
    }
    
    protected void Buton1_Click(object sender, EventArgs e)
    {
      Datatable dtable = (Datatable)ViewState["dt"];
      if (ViewState["dt"] == null)
      {
          DataColumn dc = new DataColumn("Name");
          dtable.Columns.Add(dc);
      }
          DataRow dr = dtable.NewRow();
          dr["Name"] = TextBox1.Text;
          dtable.Rows.Add(dr);
          dtable.AcceptChanges();
          GridView1.DataSource = dtable;
          GridView1.DataBind();
          ViewState["dt"] = dtable;
    }
