    private DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CreateDataTable();
            sno.Text = "1";
        }
    }
    private DataTable CreateDataTable()
    {
        dt = new DataTable();
        dt.Columns.Add("Sn#");
        dt.Columns.Add("type");
        dt.Columns.Add("AccountTitle");
        dt.Columns.Add("Description");
        dt.Columns.Add("CostCenter");
        dt.Columns.Add("Debit");
        dt.Columns.Add("Credit");
        return dt;
    }
    private DataTable AddRow(DataTable dt1)
    { // method to create row
        DataRow dr = dt1.NewRow();
        dr[0] = sno.Text;
        dr[1] = type.Text;
        dr[2] = htitle.Text;
        dr[3] = disc.Text;
        dr[4] = job.SelectedItem.Text;
        dr[5] = drr.Text;
        dr[6] = crr.Text;
        dt1.Rows.Add(dr);
        return dt1;
    }  
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        rg.DataSource = ViewState["dt"] as DataTable;    
    }
    protected void b1_Click(object sender, EventArgs e)
    {
        DataTable dt1 = ViewState["dt"] != null ? ViewState["dt"] as DataTable : CreateDataTable();
        ViewState["dt"] = AddRow(dt);
        rg.Rebind();
        Session["cttt"] = Convert.ToInt32(sno.Text) + 1;
        sno.Text = Session["cttt"].ToString();
    }
