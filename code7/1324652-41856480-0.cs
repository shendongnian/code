    var fecRamps = new FilteredElementCollector(doc)
        .OfClass(typeof(FamilyInstance))
        .Where(pElt =>
        {
            int lCatId = pElt.Category.Id.IntegerValue;
            return lCatId == (int)BuiltInCategory.OST_Ramps;
        })
        .OfType<FamilyInstance>()
        .ToList();
    List<XYZ> lRampLocs = new List<XYZ>();
    foreach (var pFam in fecRamps)
    {
        var fLoc = pFam.Location as LocationCurve;
        var fRampSide1 = new XYZ(fLoc.Curve.GetEndPoint(0);
        var fRampSide2 = new XYZ(fLoc.Curve.GetEndPoint(1);
        lRampLocs.Add(fRampSide1);
        lRampLocs.Add(fRampSide2);
    }
    
