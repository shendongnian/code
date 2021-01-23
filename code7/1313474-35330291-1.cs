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
    foreach (Field2 fld in db.TableDefs["TestTable1"].Fields)
    {
        if (fld.Expression.Length > 0)
        {
            Console.WriteLine("Field [{0}] is calculated.", fld.Name);
        }
    }
    db.Close();
