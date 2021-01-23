    List<ObjectId> ids;
    [CommandMethod("CMD1")]
    public void Cmd1()
    {
      Document doc = Application.DocumentManager.MdiActiveDocument;
      ids = new List<ObjectId>();
      doc.CommandEnded += Doc_CommandEnded;
      doc.SendStringToExecute("_CMD2 0 ", false, false, true);
    }
    private void Doc_CommandEnded(object sender, CommandEventArgs e)
    {
      if (e.GlobalCommandName != "CMD2") return;
      
      ids.Add(Utils.EntLast());
      var doc = (Document) sender;
      if (ids.Count < 10)
      {
        double angle = ids.Count * Math.PI / 10;
        doc.SendStringToExecute("_CMD2 " + Converter.AngleToString(angle) + "\n", false, false, true);
      }
      else
      {
        doc.CommandEnded -= Doc_CommandEnded;
        doc.Editor.WriteMessage("\nHandles: {0}", string.Join(", ", ids.Select(id => id.Handle.ToString())));
      }
    }
    [CommandMethod("CMD2")]
    public void Cmd2()
    {
      Document doc = Application.DocumentManager.MdiActiveDocument;
      Database db = doc.Database;
      PromptDoubleResult pdr = doc.Editor.GetAngle("\nAngle: ");
      if (pdr.Status == PromptStatus.Cancel) return;
      using (Transaction tr = db.TransactionManager.StartTransaction())
      {
        var line = new Line(new Point3d(), new Point3d(Math.Cos(pdr.Value), Math.Sin(pdr.Value), 0));
        var currentSpace = (BlockTableRecord) tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);
        currentSpace.AppendEntity(line);        
        tr.AddNewlyCreatedDBObject(line, true);
        tr.Commit();
      }
    }
