static void AddRegAppTableRecord(string regAppName)
    {
      Document doc =
        Application.DocumentManager.MdiActiveDocument;
      Editor ed = doc.Editor;
      Database db = doc.Database;
      Transaction tr =
        doc.TransactionManager.StartTransaction();
      using (tr)
      {
        RegAppTable rat =
          (RegAppTable)tr.GetObject(
            db.RegAppTableId,
            OpenMode.ForRead,
            false
          );
        if (!rat.Has(regAppName))
        {
          rat.UpgradeOpen();
          RegAppTableRecord ratr =
            new RegAppTableRecord();
          ratr.Name = regAppName;
          rat.Add(ratr);
          tr.AddNewlyCreatedDBObject(ratr, true);
        }
        tr.Commit();
      }
    }
