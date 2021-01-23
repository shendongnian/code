    foreach (Autodesk.Revit.DB.BoundarySegment boundSeg in boundSegList)
    {
      Element el = doc.GetElement(boundSeg.ElementId); // or doc.GetElement(boundSeg.LinkElementId);
      if ((BuiltInCategory)el.Category.Id.IntegerValue == BuiltInCategory.OST_RoomSeparationLines)
      {
    
      }
    }
