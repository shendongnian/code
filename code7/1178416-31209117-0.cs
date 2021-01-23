    [CommandMethod("countPlineArea")]
    public static void CmdCountPlineArea()
    {
      double totalArea = 0.0;
          
      Database db = Application.DocumentManager.MdiActiveDocument.Database;
      using (Transaction trans = db.TransactionManager.StartTransaction())
      {
        BlockTableRecord currentSpace = trans.GetObject(db.CurrentSpaceId, OpenMode.ForRead) as BlockTableRecord;
        foreach(ObjectId entId in currentSpace)
        {
          if (entId.ObjectClass != RXClass.GetClass(typeof(Polyline))) continue;
          Polyline pline = trans.GetObject(entId, OpenMode.ForRead) as Polyline;
          if (!pline.Closed) continue; // no area
          totalArea += pline.Area;
        }
      }
    }
