    // This code requires the following COM reference in your project:
    //
    //     Microsoft Office 14.0 Access Database Engine Object Library
    //
    // and the declaration
    //
    //     using Microsoft.Office.Interop.Access.Dao;
    //
    // at the top of the class file            
    var dbe = new DBEngine();
    Database db = dbe.OpenDatabase(@"C:\Users\Public\Database1.accdb");
    string sql =
            "INSERT INTO tbl_Log (ID, DateValue) " +
            "SELECT ID, DateString " +
            "FROM tbl_Data";
    db.Execute(sql);
