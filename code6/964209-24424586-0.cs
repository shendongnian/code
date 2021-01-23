     private DataTable getData()
            {
                DataSet dss = new DataSet();
                string sql = "";
                sql = "SELECT * from VW_TransReciptReport WHERE tREC_NUPKId='" + TxtID.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dss);
                DataTable dt = dss.Tables[0];
                return dt;
            }
    
            private void runRptViewer()
            {
                this.rptviewer.Reset();
                ReportParameter rp = new ReportParameter("ID", TxtID.Text.ToString());
                this.rptviewer.LocalReport.ReportPath = Server.MapPath("ReportReceipt.rdlc");
                rptviewer.LocalReport.SetParameters(new ReportParameter[] { rp });
                ReportDataSource rdsB = new ReportDataSource("DataSet1_VW_TransReciptReport", getData());
                
                this.rptviewer.LocalReport.DataSources.Clear();
                this.rptviewer.LocalReport.DataSources.Add(rdsB);
               
                this.rptviewer.DataBind();
                this.rptviewer.LocalReport.Refresh();
            }
