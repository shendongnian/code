    #if !VERSION2014
        var direction = new XYZ(-1, 1, -1);
        var view3D = doc.IsFamilyDocument
          ? doc.FamilyCreate.NewView3D(direction)
          : doc.Create.NewView3D(direction);
    #else
        var collector = new FilteredElementCollector(
          doc );
     
        var viewFamilyType = collector
          .OfClass( typeof( ViewFamilyType ) )
          .OfType<ViewFamilyType>()
          .FirstOrDefault( x =>
            x.ViewFamily == ViewFamily.ThreeDimensional );
     
        var view3D = ( viewFamilyType != null )
          ? View3D.CreateIsometric( doc, viewFamilyType.Id )
          : null;
     
    #endif // VERSION2014
