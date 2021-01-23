     protected void Button5_Click(object sender, EventArgs e)
         { 
        dynamic rpt = new ReportDocument();
        ApplyCRLogin(rpt);
        DataSet dtu = new DataSet();
            // Your Stored Procedure Here 
           // Bind dtu to the ObjReport
           rpt .Database.Tables["Command"].SetDataSource(dtu.Tables[0]);
         // Here Command is name which you can see inside Field Explorer in Crystal Report Design Mode 
           // Then Pass your SP parametrs 
            rpt.SetParameterValue("@dtFromDate", txtFromDate.Text);
            rpt.SetParameterValue("@dtToDate", txtToDate.Text);
            //After this Export your Crstal Report  to  PDF
          ExportToPDF(rpt);
         }
    
         public void ApplyCRLogin(CrystalDecisions.CrystalReports.Engine.ReportDocument oRpt)
                {
                    CrystalDecisions.CrystalReports.Engine.Database oCRDb = oRpt.Database;
                    CrystalDecisions.CrystalReports.Engine.Tables oCRTables = oCRDb.Tables;
                    CrystalDecisions.Shared.TableLogOnInfo oCRTableLogonInfo;
                    CrystalDecisions.Shared.ConnectionInfo oCRConnectionInfo = new CrystalDecisions.Shared.ConnectionInfo();
                    oCRConnectionInfo.DatabaseName = "DatabaseName";
                    oCRConnectionInfo.ServerName = "DBSRV_NAME";
                    oCRConnectionInfo.UserID = "UserID";
                    oCRConnectionInfo.Password = "Password";
                    foreach (CrystalDecisions.CrystalReports.Engine.Table oCRTable in oCRTables)
                    {
                        oCRTableLogonInfo = oCRTable.LogOnInfo;
                        oCRTableLogonInfo.ConnectionInfo = oCRConnectionInfo;
                        oCRTable.ApplyLogOnInfo(oCRTableLogonInfo);
                    }
                }
 
