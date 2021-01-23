            public static void SetConnections(ReportDocument report)
        {
            Database database = report.Database;
            Tables tables = database.Tables;
            var crConnInfo = new ConnectionInfo
            {
                ServerName = ConfigurationManager.AppSettings["Server"],
                DatabaseName = ConfigurationManager.AppSettings["Database"],
                UserID = ConfigurationManager.AppSettings["DatabaseUser"],
                Password = ConfigurationManager.AppSettings["DatabasePassword"]
            };
            foreach (Table table in tables)
            {
                TableLogOnInfo crLogOnInfo = table.LogOnInfo;
                crLogOnInfo.ConnectionInfo = crConnInfo;
                table.ApplyLogOnInfo(crLogOnInfo);
            }
            Sections crSections = report.ReportDefinition.Sections;
            foreach (Section crSection in crSections)
            {
                ReportObjects crReportObjects = crSection.ReportObjects;
                foreach (ReportObject crReportObject in crReportObjects)
                {
                    if (crReportObject.Kind == ReportObjectKind.SubreportObject)
                    {
                        var crSubreportObject = (SubreportObject)crReportObject;
                        ReportDocument subRepDoc = crSubreportObject.OpenSubreport(crSubreportObject.SubreportName);
                        Database crDatabase = subRepDoc.Database;
                        Tables crTables = crDatabase.Tables;
                        foreach (Table crTable in crTables)
                        {
                            TableLogOnInfo crLogOnInfo = crTable.LogOnInfo;
                            crLogOnInfo.ConnectionInfo = crConnInfo;
                            crTable.ApplyLogOnInfo(crLogOnInfo);
                        }
                    }
                }
            }
        }
