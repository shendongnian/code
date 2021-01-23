    [CommandMethod("BAT")]
    static public void BlockAttributeTable()
    {
      Document doc = Application.DocumentManager.MdiActiveDocument;
      Database db = doc.Database;
      Editor ed = doc.Editor;
      
      PromptEntityOptions opts = new PromptEntityOptions("\nSelect a block: ");
      opts.AddAllowedClass(typeof(BlockReference), true);
      PromptEntityResult pr = ed.GetEntity(opts);
      if (pr.Status == PromptStatus.OK)
      {
        Transaction tr = doc.TransactionManager.StartTransaction();
        using (tr)
        {
          BlockReference blockRef = tr.GetObject(pr.ObjectId, OpenMode.ForRead) as BlockReference;
          BlockTableRecord bd = (BlockTableRecord)tr.GetObject(blockRef.BlockTableRecord, OpenMode.ForRead);
          foreach (ObjectId adId in bd)
          {
            // ToDo: here you can handle entities inside the block definition
          }
        }
      }
    }
