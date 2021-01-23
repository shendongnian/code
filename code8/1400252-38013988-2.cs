    [CommandMethod("FindAllHatches")]
    public static void FindAllHatches()
    {
        Document acDoc = Application.DocumentManager.MdiActiveDocument;
        acDoc.Editor.WriteMessage("\nSearching for Hatches");
        
        var db = acDoc.Database;
        using (Transaction transaction = db.TransactionManager.StartTransaction())
        {
            ObjectId idModelSpace = SymbolUtilityServices.GetBlockModelSpaceId(db);
            BlockTableRecord modelSpace =
                transaction.GetObject(idModelSpace, OpenMode.ForRead) as
                BlockTableRecord;
            var sbReportText = new StringBuilder(); //usging System.Text
            double fTotalArea = 0.0;
            int nTotalHatches = 0;
            foreach (var objId in modelSpace)
            {
                var entity = transaction.GetObject(objId, OpenMode.ForRead);
                Hatch hatch = entity as Hatch;
                if (hatch == null)
                    continue; //not hatch
                nTotalHatches++;
                fTotalArea += hatch.Area;
                acDoc.Editor.WriteMessage("\nFound Hatch Area={0}", hatch.Area);
                sbReportText.AppendFormat("Hatch Area={0}\n", hatch.Area);
            }
            if (nTotalHatches == 0)
                return; //no hatches found
            modelSpace.UpgradeOpen();
            MText acMText = new MText();
            acMText.SetDatabaseDefaults();
            sbReportText.AppendFormat("Count = {0}, Total Area = {1}",
                nTotalHatches, fTotalArea);
            acMText.Contents = sbReportText.ToString();
            modelSpace.AppendEntity(acMText);
            transaction.AddNewlyCreatedDBObject(acMText, true);
            transaction.Commit();
        }
    }
