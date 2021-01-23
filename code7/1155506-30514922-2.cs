     protected void Button1_Click1(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
         
                if (rd.SelectedValue == "1")
                {
                    CrystalReportViewer1.Visible = true;
                        DateTime to = Convert.ToDateTime(sdate.Text);
                        dbconnect a = new dbconnect();
                        ReportDocument rDoc = new ReportDocument();
                        a.OpenConnection();
                        a.cmd = new SqlCommand("viewattandace_repoeting", a.con);
                        SqlDataAdapter da = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        a.cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = a.cmd;
                        da.Fill(ds, "viewattandace_repoeting");
                        rDoc.Load(Server.MapPath("CrystalReport1.rpt"));
                        rDoc.SetDataSource(ds);
                        rDoc.SetParameterValue("date", to);
                        rDoc.SetParameterValue("depid", 1);
                        CrystalReportViewer1.ReportSource = rDoc;
                        CrystalReportViewer1.DataBind();
                        CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                                      a.CloseConnection();
                     
                    
                    
                }
                else
                    if (rd.SelectedValue == "2")
                    {
                        CrystalReportViewer2.Visible = true;
                        sd = Convert.ToDateTime(m.SelectedItem.Text + "/" + "1" + "/" + yt.SelectedItem.Text);
                        ed = LastDayOfMonth(sd);
                        dbconnect a = new dbconnect();
                        ReportDocument rDoc = new ReportDocument();
                   
                            a.OpenConnection();
                            a.cmd = new SqlCommand("viewattandace_repoeting", a.con);
                            SqlDataAdapter da = new SqlDataAdapter();
                            DataSet ds = new DataSet();
                            a.cmd.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand = a.cmd;
                            da.Fill(ds, "viewattandace_repoeting");
                            rDoc.Load(Server.MapPath("employeemonthly.rpt"));
                            rDoc.SetDataSource(ds);
                            rDoc.SetParameterValue("sdate", sd);
                            rDoc.SetParameterValue("edate", ed);
                            rDoc.SetParameterValue("depid", 1);
                            rDoc.SetParameterValue("email", eet.Text.Trim());
                            CrystalReportViewer2.ReportSource = rDoc;
                            CrystalReportViewer2.DataBind();
                            CrystalReportViewer2.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                            a.CloseConnection();
}
}
