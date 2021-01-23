        ReportDocument cryRpt = new ReportDocument();
        TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
        TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
        ConnectionInfo crConnectionInfo = new ConnectionInfo();
        Tables CrTables;
        string path = "C:/Users/nbousaba/Documents/Visual Studio 2013/Projects/WindowsFormsApplication4/WindowsFormsApplication4/Report1.rpt";
        cryRpt.Load(path);
        cryRpt.SetParameterValue("@MoM_ID", x);
        crConnectionInfo.ServerName = ".";
        crConnectionInfo.DatabaseName = "MoM";
        crConnectionInfo.UserID = "sa";
        crConnectionInfo.Password = "123456";
        CrTables = cryRpt.Database.Tables;
        foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
        {
            crtableLogoninfo = CrTable.LogOnInfo;
            crtableLogoninfo.ConnectionInfo = crConnectionInfo;
            CrTable.ApplyLogOnInfo(crtableLogoninfo);
        }
        crystalReportViewer1.ReportSource = cryRpt;
        crystalReportViewer1.Refresh();
        //Creating a PDF file from Crystal Report
        try
        {
            ExportOptions CrExportOptions;
            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
            CrDiskFileDestinationOptions.DiskFileName = "c:\\MoM_Form"+x+".pdf";
            CrExportOptions = cryRpt.ExportOptions;
            {
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                CrExportOptions.FormatOptions = CrFormatTypeOptions;
            }
            cryRpt.Export();
