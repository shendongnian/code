    /// <summary>
    /// Recalculate the position for a bottom left coordinate.
    /// Must be called after GenerateLayout().
    /// </summary>
    /// <param name="tbl">Table object</param>
    /// <param name="bottomLeft">Bottom Left desired position</param>
    public static void MoveToBottomLeft(this Table tbl, Point3d bottomLeft)
    {
      Point3d maxPoint = tbl.Bounds.Value.MaxPoint; // this is the bottom left (min point)
      Point3d topLeft = new Point3d(maxPoint.Y, bottomLeft.Y, bottomLeft.Z); // this should be topLeft
      Point3d newPosition = bottomLeft.TransformBy(Matrix3d.Displacement(bottomLeft.GetVectorTo(newPosition))); // move bottomLeft to newPosition
      tbl.Position = newPosition; // apply the new position
    }
