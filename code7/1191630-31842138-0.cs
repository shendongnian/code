    using (Transaction tr = db.TransactionManager.StartTransaction())
    {
      RegAppTable regAppTable = (RegAppTable)tr.GetObject(db.RegAppTableId, OpenMode.ForRead, false);
      if (!regAppTable.Has("MY_OBJECT"))
      {
        regAppTable.UpgradeOpen();
        RegAppTableRecord ratr = new RegAppTableRecord();
        ratr.Name = "MY_OBJECT";
        regAppTable.Add(ratr);
        tr.AddNewlyCreatedDBObject(ratr, true);
      }
      tr.Commit();
    }
    using (Transaction tr = db.TransactionManager.StartTransaction())
    {
      BlockTableRecord btr = (BlockTableRecord)tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);
      List<TypedValue> xdata = new List<TypedValue>
      {
        new TypedValue(1001, "MY_OBJECT"),
        new TypedValue(1070, 1234)
      };
      var resBuffer = new ResultBuffer(xdata.ToArray());
      p.XData = resBuffer;
      btr.AppendEntity(p);
      tr.AddNewlyCreatedDBObject(p, true);
      tr.Commit();
    }
