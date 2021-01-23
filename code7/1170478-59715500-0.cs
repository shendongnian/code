            var package = new ExcelPackage(new MemoryStream());
            var ws = package.Workbook.Worksheets.Add("Test");
            var modelTable = ws.Cells;
            modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            modelTable.AutoFitColumns();
            // calculate
            ws.Calculate();
            saveFileDialog_SaveExcel.Filter = "Excel files (*.xlsx)|*.xlsx";
            var dialogResult = saveFileDialog_SaveExcel.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                package.SaveAs(new FileInfo(saveFileDialog_SaveExcel.FileName));
            }
