    var dbPath = "[path to your db]";
    
    var guid = Guid.NewGuid().ToString();
    var tempPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), guid);
    System.IO.Directory.CreateDirectory(tempPath);
    var tempDb = Path.Combine(tempPath, "[yourdbname]");
    System.IO.File.Copy("[path to your db]", tempDb, true);
    
    //copy the old database to this tempPath
    //Overwrite the original old db with your new one
    var access = new Microsoft.Office.Interop.Access.Application();
    access.OpenCurrentDatabase(filepath: "[path to your db]", Exclusive: true, bstrPassword: "");
    var newdb = access.CurrentDb();
    var tableList=new List<string>();
    foreach (TableDef table in newdb.TableDefs)
    {
    	tableList.Add(table.Name);
    	newdb.TableDefs.Delete(table.Name);
    }
    foreach (var table in tableList)
    {
    	access.DoCmd.TransferDatabase(AcDataTransferType.acImport, DatabaseTypeEnum.dbVersion140, tempDb,
    		AcObjectType.acTable, table, table, false, false);
    }
    System.IO.Directory.Delete(tempPath, true);
