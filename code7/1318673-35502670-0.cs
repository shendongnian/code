     bool IsCellBeingEdited(Excel.Application excelApp)
     {
       CORE.CommandBarControl cbc = excelApp.CommandBars.FindControl(1, 18, System.Type.Missing, System.Type.Missing);
       return cbc != null && !cbc.Enabled;
     }
