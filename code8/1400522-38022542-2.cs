    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Worksheet 1");
    System.Data.DataTable dataTable = Project1.SomeClass.GetDataTable();
    
    foreach (Project1.SomeClass someClassObject in myList)
    {
    	dataTable.Rows.Add(someClassObject.GetDataRow());
    }
