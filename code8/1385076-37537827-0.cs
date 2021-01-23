                ConnectionInfo connectionInfo = new ConnectionInfo();
                ReportDocument RepDoc = new ReportDocument();
                connectionInfo.ServerName = ".";
                connectionInfo.DatabaseName = "taxi1";
                string RepPath = Path.Combine(Application.StartupPath,"CrystalReport2.rpt")
                RepDoc.Load(RepPath);
                RepDoc.SetDataSource(ds);
                crystalReportViewer1.ReportSource = RepDoc;
