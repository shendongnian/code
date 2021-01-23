    // required COM reference: Microsoft Office 14.0 Access Database Engine Object Library
    //
    // using Microsoft.Office.Interop.Access.Dao; ...
    var dbe = new DBEngine();
    Database db = dbe.OpenDatabase(@"C:\Users\Public\Database1.accdb");
    TableDef tbd = db.TableDefs["MyTable"];  // existing table
    var fld = new Field();
    fld.Name = "MyRichMemo";
    fld.Type = (short) DataTypeEnum.dbMemo;
    tbd.Fields.Append(fld);
    // now set "Text Format" property to "Rich Text"
    fld.Properties.Append(fld.CreateProperty("TextFormat", DataTypeEnum.dbByte, 1));
    db.Close();
