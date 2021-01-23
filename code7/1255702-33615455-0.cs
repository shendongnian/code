    // required COM reference:
    //     Microsoft Office 14.0 Access Database Engine Object Library
    var dbe = new Microsoft.Office.Interop.Access.Dao.DBEngine();
    Microsoft.Office.Interop.Access.Dao.Database db = dbe.OpenDatabase(
            @"C:\Users\Public\Database1.accdb");
    Microsoft.Office.Interop.Access.Dao.Recordset rst = db.OpenRecordset(
            "SELECT [Id], [Name] FROM [Cars] WHERE FALSE", 
            Microsoft.Office.Interop.Access.Dao.RecordsetTypeEnum.dbOpenDynaset);
    
    rst.AddNew();
    // new records are immediately assigned an AutoNumber value ...
    string newReplId = rst.Fields["Id"].Value;  // ... so retrieve it
    // the returned string is of the form
    //     {guid {1D741E80-6847-4CB2-9D96-35F460AEFB19}}
    // so remove the leading and trailing decorators
    newReplId = newReplId.Substring(7, newReplId.Length - 9);
    // add other field values as needed
    rst.Fields["Name"].Value = "Pagani";
    // commit the new record
    rst.Update();
    db.Close();
    Console.WriteLine("New record added with [Id] = {0}", newReplId);
