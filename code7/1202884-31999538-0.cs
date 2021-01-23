    private static void AlignBlock(ObjectId lineId, ObjectId blockId)
    {
      if (lineId.ObjectClass != RXClass.GetClass(typeof(Line)))
        throw new Autodesk.AutoCAD.Runtime.Exception(ErrorStatus.InvalidInput, "1st parameter must be a line");
      if (blockId.ObjectClass != RXClass.GetClass(typeof(BlockReference)))
        throw new Autodesk.AutoCAD.Runtime.Exception(ErrorStatus.InvalidInput, "2nd parameter must be a block");
    
      Database db = lineId.Database;
      using (Transaction trans = db.TransactionManager.StartTransaction())
      {
        Line line = trans.GetObject(lineId, OpenMode.ForRead) as Line;
        BlockReference blockRef = trans.GetObject(blockId, OpenMode.ForWrite) as BlockReference;
    
        // better use the center point, instead min/max
        Extents3d blockExtents = blockRef.Bounds.Value;
        Point3d minPoint = blockExtents.MinPoint;
        Point3d maxPoint = blockExtents.MaxPoint;
    
        Point3d pointOverLine = line.GetClosestPointTo(minPoint, false);
        Matrix3d blockTranslate = Matrix3d.Displacement(minPoint.GetVectorTo(pointOverLine));
        blockRef.TransformBy(blockTranslate); // move
    
        // assuming a well behaved 2D block aligned with XY
        Vector3d lineDirection = line.GetFirstDerivative(pointOverLine);
        Vector3d blockDirection = minPoint.GetVectorTo(new Point3d(maxPoint.X, minPoint.Y, 0)); // basically a X vector
        double angleToRotate = lineDirection.GetAngleTo(blockDirection);
        Matrix3d blockRotate = Matrix3d.Rotation(angleToRotate, Vector3d.ZAxis, pointOverLine);
        blockRef.TransformBy(blockRotate); // rotate
    
        trans.Commit();
      }
    }
