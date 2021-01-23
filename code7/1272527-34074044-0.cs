    var accessApp = new Microsoft.Office.Interop.Access.Application();
    accessApp.OpenCurrentDatabase(@"Database1.accdb"); //Change accordingly.
    Microsoft.Office.Interop.Access.Dao.Database cdb = accessApp.CurrentDb();
    Microsoft.Office.Interop.Access.Dao.Recordset recordSet = 
    cdb.OpenRecordset(
    "SELECT * FROM QueryName", 
    Microsoft.Office.Interop.Access.Dao.RecordsetTypeEnum.dbOpenSnapshot); //Change query name accordingly.
    while (!recordSet.EOF)
    {
        Console.WriteLine(recordSet.Fields["FieldName"].Value); //Again change if needed. Just an example.
        recordSet.MoveNext();
    }
    recordSet.Close();
    accessApp.CloseCurrentDatabase();
    accessApp.Quit(); 
