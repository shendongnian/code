    protected void Button5_Click(object sender, EventArgs e)
     { 
    dynamic rpt = new ReportDocument();
    ApplyCRLogin(rpt);
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
