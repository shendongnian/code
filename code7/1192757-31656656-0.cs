    ReportDocument rptDoc = new ReportDocument();
			
	protected void Page_Init(object sender, EventArgs e)
	{
		// Load the report path
		string reportPath = Server.MapPath("~/CrystalReportTime.rpt");
		rptDoc.Load(reportPath);
		CrystalReportViewer1.ReportSource = rptDoc;	
	}
	protected void Page_Load(object sender, EventArgs e)
	{
			
		if (!IsPostBack)
		{
			string reportPath = Server.MapPath("~/CrystalReportTime.rpt");
			rptDoc.Load(reportPath);
			CrystalReportViewer1.ReportSource = rptDoc;
		}
		DataSet ds = new DataSet();
		DataTable dt = new DataTable();
		dt.Columns.Add("Name", typeof(String));      
		dt.Columns.Add("Class", typeof(String));
		dt.Columns.Add("RollNo", typeof(String));
		foreach (DataGridViewRow dgr in dgv_Student.Rows)
		{
		  dt.Rows.Add(dgr.Cells["Name"].Value, dgr.Cells["Class"].Value, dgr.Cells["RollNo"].Value);
		}
		ds.Tables.Add(dt); 
		rptDoc.SetDataSource(ds);
		
		// Pass the time to the Crystal Reports text object
		CrystalDecisions.CrystalReports.Engine.TextObject Text1;
		Text1 = rptDoc.ReportDefinition.ReportObjects["Text1"] as TextObject;
		Text1.Text = "Time from " + String.Format("{0:MMMM dd, yyyy}", Convert.ToDateTime(dtpFrom)) + " to " + String.Format("{0:MMMM dd, yyyy}", Convert.ToDateTime(dtpTo));
	}
	protected void Page_UnLoad(object sender, EventArgs e)
	{
		this.CrystalReportViewer1.Dispose();
		this.CrystalReportViewer1 = null;
		rptDoc.Close();
		rptDoc.Dispose();
		rptDoc = null;
		GC.Collect();
	}
