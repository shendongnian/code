        //Assign data source details to the report viewer
        if (this.crystalReportViewer1.LogOnInfo != null)
        {
            TableLogOnInfos tlInfo = this.crystalReportViewer1.LogOnInfo;
            foreach (TableLogOnInfo tbloginfo in tlInfo)
            {
                tbloginfo.ConnectionInfo = tConnInfo;
            }
        }
        crystalReportViewer1.ReportSource = crReport;
