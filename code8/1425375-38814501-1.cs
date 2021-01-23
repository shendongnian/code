    [CommandMethod("AddFileNameText")]
    public static void AddFileNameText()
    {
        Document acDoc = Application.DocumentManager.MdiActiveDocument;
        var db = acDoc.Database;
        using (Transaction transaction = db.TransactionManager.StartTransaction())
        {
            ObjectId idModelSpace = SymbolUtilityServices.GetBlockModelSpaceId(db);
            BlockTableRecord modelSpace =
                transaction.GetObject(idModelSpace, OpenMode.ForWrite) as
                BlockTableRecord;
            MText acMText = new MText();
            acMText.SetDatabaseDefaults();
            string strFilePath = db.Filename; //c:\534-W1A-R1.dwg
            strFilePath = 
                System.IO.Path.GetFileNameWithoutExtension(strFilePath); //534-W1A-R1
            //Do ANY text processing            
            if (strFilePath.IndexOf('-') > 0)
                strFilePath = strFilePath.Substring(
                    strFilePath.IndexOf('-') + 1); //W1A-R1
            
            acMText.Contents = strFilePath;
            modelSpace.AppendEntity(acMText);
            transaction.AddNewlyCreatedDBObject(acMText, true);
            transaction.Commit();
        }
    }
