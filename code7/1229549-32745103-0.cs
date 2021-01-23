    Document document = Application.DocumentManager.MdiActiveDocument;
    Database database = document.Database;
    
    using(Transaction transaction = database.TransactionManager.StartTransaction())
    {
       BlockTable blockTable = transaction.GetObject(database.BlockTableId, OpenMode.ForRead) as BlockTable;
       BlockTableRecord blockTableRecord = transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
       Polyline polyline = new Polyline();
       polyline.AddVertexAt(0, new Point2d(0.0, 0.0), 0, 0, 0);
       polyline.AddVertexAt(1, new Point2d(100.0, 100.0), 0, 0, 0);
       polyline.AddVertexAt(2, new Point2d(50.0, 500.0), 0, 0, 0);
       polyline.Closed = true;
       blockTableRecord.AppendEntity(polyline);
       transaction.AddNewlyCreatedDBObject(polyline, true);
       Extents3d boundary = polyline.GeometricExtents;
       Point3d center = (new LineSegment3d(boundary.MinPoint, boundary.MaxPoint)).MidPoint;
       polyline.TransformBy(Matrix3d.Scaling(1, center));
       transaction.commit();
    }
