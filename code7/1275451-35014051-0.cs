    for (copyNo = 1; copyNo <= noCopies; copyNo++)
    {
        objRpt.SetParameterValue("copyNo", copyNo);
        CrystalReportViewer1.ViewerCore.ReportSource = objRpt;
        objRpt.PrintToPrinter(1, false, 0, 0);
        ...
    }
