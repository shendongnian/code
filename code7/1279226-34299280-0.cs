        public static CrystalReportSource Crystal_SetDataSource(string reportName, object par1, object par2, object par3)
        {
            CrystalReportSource CrystalReportSource2 = new CrystalReportSource();
            CrystalReportSource2.CacheDuration = 10;
            
            CrystalReportSource2.Report.FileName = @"~\App_Pages\Secure\Reports\" + reportName;
            CrystalDecisions.CrystalReports.Engine.Database crDatabase = CrystalReportSource2.ReportDocument.Database;
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = server;
            crConnectionInfo.DatabaseName = db;
            crConnectionInfo.UserID = crystalUser;
            crConnectionInfo.Password = pwd;
            crConnectionInfo.IntegratedSecurity = false;
            // First we assign the connection to all tables in the main report
            TableLogOnInfo crTableLogOnInfo = new TableLogOnInfo();
            foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in crDatabase.Tables)
            {
                crTableLogOnInfo = crTable.LogOnInfo;
                crTableLogOnInfo.ConnectionInfo = crConnectionInfo;
                crTable.ApplyLogOnInfo(crTableLogOnInfo);
            }
            //SET DATASOURCE FOR EACH SUBREPORT IN REPORT
            foreach (CrystalDecisions.CrystalReports.Engine.Section section in CrystalReportSource2.ReportDocument.ReportDefinition.Sections)
            {
                // In each section we need to loop through all the reporting objects
                foreach (CrystalDecisions.CrystalReports.Engine.ReportObject reportObject in section.ReportObjects)
                {
                    if (reportObject.Kind == ReportObjectKind.SubreportObject)
                    {
                        SubreportObject subReport = (SubreportObject)reportObject;
                        ReportDocument subDocument = subReport.OpenSubreport(subReport.SubreportName);
                        foreach (CrystalDecisions.CrystalReports.Engine.Table table in subDocument.Database.Tables)
                        {
                            // Cache the logon info block
                            TableLogOnInfo logOnInfo = table.LogOnInfo;
                            // Set the connection
                            logOnInfo.ConnectionInfo = crConnectionInfo;
                            // Apply the connection to the table!
                            table.ApplyLogOnInfo(logOnInfo);
                        }
                    }
                }
            }
            
            if (CrystalReportSource2.ReportDocument.DataSourceConnections.Count > 0)
                CrystalReportSource2.ReportDocument.DataSourceConnections[0].SetConnection(server, db, crystalUser, pwd);
            CrystalReportSource2.ReportDocument.SetDatabaseLogon(crystalUser, pwd, server, db);
            if (par1 != null)
                CrystalReportSource2.ReportDocument.SetParameterValue(0, par1);
            if (par2 != null)
                CrystalReportSource2.ReportDocument.SetParameterValue(1, par2);
            if (par3 != null)
                CrystalReportSource2.ReportDocument.SetParameterValue(2, par3);
            return CrystalReportSource2;
        }
