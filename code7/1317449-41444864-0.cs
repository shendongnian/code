    package.Workbook.CreateVBAProject();
    OfficeOpenXml.VBA.ExcelVBAModule excelVbaModule =
                       package.Workbook.VbaProject.Modules.AddModule("Module1");
    System.Text.StringBuilder mac = new System.Text.StringBuilder();
    mac.AppendLine("Sub Auto_Start()");
    mac.AppendLine("Sheets(2).Select");
    mac.AppendLine("ActiveSheet.ChartObjects(\"chartWeeklyReport\").Activate");
    mac.AppendLine("ActiveChart.FullSeriesCollection(1).DataLabels.Select");
    mac.AppendLine("Selection.Position = xlLabelPositionAbove");
    mac.AppendLine("Selection.Orientation = xlUpward");
    mac.AppendLine("Selection.Position = xlLabelPositionAbove");
    mac.AppendLine("End Sub");
    excelVbaModule.Code = mac.ToString();
    package.Save();
