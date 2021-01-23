    [CommandMethod("SEL")]
    public void MySelection()
    {
        Document doc = Autodesk.AutoCAD
            .ApplicationServices.Application
            .DocumentManager.MdiActiveDocument;
        Editor ed = doc.Editor;
     
        Point3d p1 = new Point3d(10.0, 10.0, 0.0);
        Point3d p2 = new Point3d(10.0, 11.0, 0.0);
        Point3d p3 = new Point3d(11.0, 11.0, 0.0);
        Point3d p4 = new Point3d(11.0, 10.0, 0.0);
     
        Point3dCollection pntCol =
                          new Point3dCollection();
        pntCol.Add(p1);
        pntCol.Add(p2);
        pntCol.Add(p3);
        pntCol.Add(p4);
     
        int numOfEntsFound = 0;
     
        PromptSelectionResult pmtSelRes = null;
     
        TypedValue[] typedVal = new TypedValue[1];
        typedVal[0] = new TypedValue
                     ((int)DxfCode.Start, "Line");
     
        SelectionFilter selFilter =
                  new SelectionFilter(typedVal);
        pmtSelRes = ed.SelectCrossingPolygon
                             (pntCol, selFilter);
        // May not find entities in the UCS area
        // between p1 and p3 if not PLAN view
        // pmtSelRes =
        //    ed.SelectCrossingWindow(p1, p3, selFilter);
     
        if (pmtSelRes.Status == PromptStatus.OK)
        {
            foreach (ObjectId objId in
                pmtSelRes.Value.GetObjectIds())
            {
                numOfEntsFound++;
            }
            ed.WriteMessage("Entities found " +
                        numOfEntsFound.ToString());
        }
        else
            ed.WriteMessage("\nDid not find entities");
    }
