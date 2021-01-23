    [CommandMethod("CHX")]
    public void ChangeXref()
    {
      var doc = Application.DocumentManager.MdiActiveDocument;
      if (doc == null) return;
    
      var ed = doc.Editor;
      var db = doc.Database;
    
      // Get the database associated with each xref in the
      // drawing and change all of its circles to be dashed
    
      using (var tr = db.TransactionManager.StartTransaction())
      {
        var bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
        var ms = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead);
    
        // Loop through the contents of the modelspace
        foreach (var id in ms)
        {
          // We only care about BlockReferences
          var br = tr.GetObject(id, OpenMode.ForRead) as BlockReference;
          if (br != null)
          {
            // Check whether the associated BlockTableRecord is
            // an external reference
            var bd = (BlockTableRecord)tr.GetObject(br.BlockTableRecord, OpenMode.ForRead);
            if (bd.IsFromExternalReference)
            {
              // If so, get its Database and call the function
              // to change the linetype of its Circles
    
              var xdb = bd.GetXrefDatabase(false);
              if (xdb != null)
              {
    
                using (var xf = XrefFileLock.LockFile(xdb.XrefBlockId))
                {
                  // Make sure the original symbols are loaded
                  xdb.RestoreOriginalXrefSymbols();
    
                  xdb.RestoreForwardingXrefSymbols();
                }
    
              }
            }
          }
        }
        tr.Commit();
      }
    }
