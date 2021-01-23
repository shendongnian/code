    using (ReportDocument report = new ReportDocument())
    {
        using (CrystalReportViewer viewer = new CrystalReportViewer())
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"Destination path here");
            report.Load(System.Web.Hosting.HostingEnvironment.MapPath(@"Path to .rpt file here"));
            report.SetDatabaseLogon(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"]);
            ExportOptions options = new ExportOptions();
            DiskFileDestinationOptions diskFileOptions = new DiskFileDestinationOptions();
            diskFileOptions.DiskFileName = path + "TestReport.xls";
            options.ExportDestinationType = ExportDestinationType.DiskFile;
            options.ExportFormatType = ExportFormatType.Excel;
            options.ExportDestinationOptions = diskFileOptions;
            //These two lines below are important. The report won't generate without them.
            viewer.ReportSource = report;
            viewer.RefreshReport();
            //Just deleting the file if it exists.
            if (File.Exists(diskFileOptions.DiskFileName))
                File.Delete(diskFileOptions.DiskFileName);
            report.ExportToDisk(ExportFormatType.Excel, diskFileOptions.DiskFileName);
        }
    }
