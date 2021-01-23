    private DataTable GetData(Int64 id_doc)
    {
    
        DataTable dt = new DataTable();
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringloginDb"].ConnectionString;
        try
        {
            using (var conn = new MySqlConnection(connStr))
            {
                string sSQL = "SELECT c.*, users.*, t.*, d.* FROM head_doc h INNER JOIN doc_details d ON h.id_doc = d.id_doc INNER JOIN clients c ON c.id_client = h.id_client INNER JOIN users ON h.id_user = users.id_user WHERE (h.id_doc = @par1) AND (h.id_client = @par2)";
                MySqlCommand cmd = new MySqlCommand(sSQL, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new MySqlParameter("@par1", Session["id_doc"].ToString()));
                cmd.Parameters.Add(new MySqlParameter("@par2", Session["id_client"].ToString()));
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dt);
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
        return dt;
    }
    
    protected void showReport()
    {
        DataTable DataTable1 = GetData(Convert.ToInt64(Session["id_doc"].ToString()));
        report.LocalReport.Refresh();
        report.Reset();
        report.LocalReport.EnableExternalImages = true;
        this.report.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
        //Aggiunta dataset
        ReportDataSource rds2 = new ReportDataSource("DataSet2", DataTable1);
        report.LocalReport.DataSources.Add(rds2);
        //Path
        report.LocalReport.ReportPath = "ReportFatture.rdlc";
        //Parameters
        ReportParameter rptParam = new ReportParameter("par1", Session["id_doc"].ToString());
        ReportParameter rptParam2 = new ReportParameter("par2", Session["id_client"].ToString());
        report.LocalReport.SetParameters(rptParam);
        report.LocalReport.SetParameters(rptParam2);
        report.LocalReport.Refresh();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
    
            if ((Session["id_doc"] != null) && (Session["id_client"] != null))
            {
                showReport();
            }
            else
            {
                Response.Redirect("/Pages/Account/Whops.aspx");
            }
        }
    }
