            Microsoft.Office.Interop.Excel.Application appExcel = new Microsoft.Office.Interop.Excel.Application();
            appExcel.Visible = true;
            //If you go with this route, use appExcel.AddIns["Solver Add-In"].Installed() to check if solver is installed before continue
            Microsoft.Office.Interop.Excel.Workbook workBook = appExcel.Workbooks.Open("C:\\yourPathHere\\yourWorkbookWithWrapperMacroHere.xlsm",
        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing);
            appExcel.Run("SolverOkWrapper", "$A1$1", 1, 0, "$B$1", 1, "GRG Nonlinear");
