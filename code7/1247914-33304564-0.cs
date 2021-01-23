	protected void Page_Load(System.Object sender, System.EventArgs e) {
		if (Page.IsPostBack) {
			if (Session.Item("CRpt") != null) {
				rdoc = Session.Item("CRpt");
			}
			CrystalReportViewer1.ReportSource = rdoc;
			CrystalReportViewer1.RefreshReport();
		} else {
            'NOT POSTBACK
		}
	}
