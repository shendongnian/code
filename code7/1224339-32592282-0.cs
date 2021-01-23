    [CommandMethod("CREATESUBDMESH")]
    public void CreateSubDMesh()
    {
      Document doc = Application.DocumentManager.MdiActiveDocument;
      Database db = doc.Database;
      Editor ed = doc.Editor;
      using (Transaction tr = db.TransactionManager.StartTransaction())
      {
        var mesh = new SubDMesh();
        mesh.Setbox(100, 100, 100, 1, 1, 1, 0);
        var currentSpace = (BlockTableRecord) tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);
        currentSpace.AppendEntity(mesh);
        tr.AddNewlyCreatedDBObject(mesh, true);
        tr.Commit();
      }
    }
