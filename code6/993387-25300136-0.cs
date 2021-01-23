    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
        ReportDocument rptDoc = new ReportDocument();
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                // Get the DataTable form the DataSet               
                DataTable dt = yourDataSet.Tables[0];  // Or use the table name like this yourDataSet.Tables["TableName"];
                
                string reportPath = Server.MapPath("~/App_Data/CrystalReport1.rpt");
                rptDoc.Load(reportPath);
                rptDoc.SetDataSource(dt);
                CrystalReportViewer1.ReportSource = rptDoc;
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = ex.Message;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Clear error message if any.
                lblErrMsg.Text = "";
                // Crystal Report Fill
                DataTable dt = yourDataSet.Tables[0];
                rptDoc.SetDataSource(dt);
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = ex.Message;
            }
        }
        protected void Page_UnLoad(object sender, EventArgs e)
        {
            try
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rptDoc.Close();
                rptDoc.Dispose();
                rptDoc = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = ex.Message;
            }
        }
