    [CommandMethod("FindAllHatches")]
    public static void FindAllHatches()
    {
        Document acDoc = Application.DocumentManager.MdiActiveDocument;
        acDoc.Editor.WriteMessage("\nSearching for Hatches");
        
        var db = acDoc.Database;
        using (Transaction transaction = db.TransactionManager.StartTransaction())
        {
            ObjectId idModelSpace = SymbolUtilityServices.GetBlockModelSpaceId(db);
            BlockTableRecord modelSpace = transaction.GetObject(idModelSpace, OpenMode.ForRead) as
                BlockTableRecord;
            foreach (var objId in modelSpace)
            {
                var entity = transaction.GetObject(objId, OpenMode.ForRead);
                Hatch hatch = entity as Hatch;
                if (hatch == null)
                    continue; //not hatch
                acDoc.Editor.WriteMessage("\nFound Hatch Area={0}", hatch.Area);
            }            
        }
    }
