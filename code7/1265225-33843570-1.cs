    // test data
    string dbFileSpec = @"C:\Users\Public\Database1.accdb";
    string tblName = "Clients";
    string colName = "LastName";
    // COM reference required for project:
    // Microsoft Office 14.0 Access Database Engine Object Library
    //
    var dbe = new Microsoft.Office.Interop.Access.Dao.DBEngine();
    Microsoft.Office.Interop.Access.Dao.Database db = dbe.OpenDatabase(dbFileSpec);
    Microsoft.Office.Interop.Access.Dao.TableDef tbd = db.TableDefs[tblName];
    bool colExists = false;
    foreach (Microsoft.Office.Interop.Access.Dao.Field fld in tbd.Fields)
    {
        if (fld.Name.Equals(colName, StringComparison.InvariantCultureIgnoreCase))
        {
            colExists = true;
            break;
        }
    }
    db.Close();
    Console.WriteLine("Column " + (colExists ? "exists" : "does not exist"));
