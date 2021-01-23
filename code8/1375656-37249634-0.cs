    Excel.DocEvents_ChangeEventHandler eventChange_CellData;
    int someStudentsScore = 99;
    
    private void Load_Workbook()
    {
        Excel.Application xlApp = new Excel.Application();
        Excel.Workbook xlBook = xlApp.Workbooks.Add();
        Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Sheets.Item[1];
    
        xlSheet.Name = "Student Data";
    
        // Your code for populating data somewhere here....
    
        eventChange_CellData = new Excel.DocEvents_ChangeEventHandler(DataChange);
    
        xlSheet.Change += eventChange_CellData;
    
    }
    
    private void DataChange(Excel.Range target)
    {
        if(target.Address == "$A$1")
        {
            // If A1 is changed, then change variable.
            someStudentsScore = target.Value2;
        }
    }
