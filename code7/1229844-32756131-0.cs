    [CommandMethod("CMD1")]
    public async void Command1()
    {
      Document doc = Application.DocumentManager.MdiActiveDocument;
      Editor ed = doc.Editor;
      await ed.CommandAsync("_CMD2");
      ed.WriteMessage("Last entity handle: {0}", Utils.EntLast().Handle);
    }
    [CommandMethod("CMD2")]
    public void Command2()
    {
      Document doc = Application.DocumentManager.MdiActiveDocument;
      Database db = doc.Database;
      using (Transaction tr = db.TransactionManager.StartTransaction())
      {
        var line = new Line(new Point3d(), new Point3d(10, 20, 30));
        var currentSpace = (BlockTableRecord) tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);
        currentSpace.AppendEntity(line);
        tr.AddNewlyCreatedDBObject(line, true);
        tr.Commit();
      }
    }
