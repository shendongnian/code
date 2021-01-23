    void AddItemsToRebarContainer(RebarContainer container, FamilyInstance beam, 
                                  RebarBarType barType, RebarHookType hookType)
    {
       // Define the rebar geometry information - Line rebar
       LocationCurve location = beam.Location as LocationCurve;
       XYZ origin = location.Curve.GetEndPoint(0);
       
       // create rebar along the length of the beam
       XYZ rebarLineEnd = location.Curve.GetEndPoint(1);
       Line line = Line.CreateBound(origin, rebarLineEnd);
       XYZ normal = new XYZ(1, 0, 0);
       Curve rebarLine = line.CreateOffset(0.5, normal);
       // Create the line rebar
       IList<Curve> curves = new List<Curve>();
       curves.Add(rebarLine);
            
       RebarContainerItem item = container.AppendItemFromCurves
       (RebarStyle.Standard, barType, hookType, hookType, normal, 
       curves, RebarHookOrientation.Right, RebarHookOrientation.Left, true, true);
    if (null != item)
     {
        // set specific layout for new rebar as fixed number, with 10 bars, 
        // distribution path length of 1.5'
        // with bars of the bar set on the same side of the rebar plane as 
        // indicated by normal and both first and last bar in the set are shown
        
        item.SetLayoutAsFixedNumber(10, 1.5, true, true, true);
     }
    }
