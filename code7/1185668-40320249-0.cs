    using XL = ClosedXML.Excel;
    ...
    XL.XLWorkbook wb = new XL.XLWorkbook();
    dsData = Session["ExportData"] as DataSet;
    var sheet1 = wb.Worksheets.Add("output table");
    sheet1.Cell(1, 1).InsertTable(dsData.Tables[0], "output table", true);
    // sheet1 is the reference sheet S1
    var dataRange = sheet1.RangeUsed();
    PivotCache cache = wb.PivotCaches.Add(dataRange); //---THIS LINE HAS BEEN ADDED---
    // First Pivot
    XL.IXLWorksheet ptSheet1 = wb.Worksheets.Add("S2");
    var pt1 = ptSheet1.PivotTables.AddNew("PivotTable1", ptSheet.Cell(3, 1), cache);
    pt1.ReportFilters.Add("CX");
    pt1.RowLabels.Add("C1");
    pt1.RowLabels.Add("C2");
    pt1.RowLabels.Add("C3");
    pt1.RowLabels.Add("C4");
    pt1.ColumnLabels.Add("CL1");
    pt1.ColumnLabels.Add("CL2");
    pt1.ColumnLabels.Add("CL3");
    pt1.Values.Add("V").SummaryFormula = XL.XLPivotSummary.Sum;
    // Second Pivot
    XL.IXLWorksheet ptSheet2 = wb.Worksheets.Add("S3");
    var pt2 = ptSheet2.PivotTables.AddNew("PivotTable2", ptSheet1.Cell(3, 1), cache);
    pt2.ReportFilters.Add("QQ");
    pt2.RowLabels.Add("C1");
    pt2.RowLabels.Add("C2");
    pt2.ColumnLabels.Add("CL1");
    pt2.ColumnLabels.Add("CL2");
    pt2.ColumnLabels.Add("CL3");
    pt2.Values.Add("V").SummaryFormula = XL.XLPivotSummary.Sum;
