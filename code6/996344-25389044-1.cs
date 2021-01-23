            Microsoft.Office.Interop.Excel.Application appExcel = new Microsoft.Office.Interop.Excel.Application();
            appExcel.Visible = true;
            Microsoft.Office.Interop.Excel.AddIn ai = appExcel.AddIns["Solver Add-In"];
            Microsoft.Office.Interop.Excel.Workbook workBook = appExcel.Workbooks.Open("C:\\yourPathHere\\yourWorkbookWithWrapperMacroHere.xlsm",
        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing);
            appExcel.Run("SolverOkWrapper", "$A1$1", 1, 0, "$B$1", 1, "GRG Nonlinear");
