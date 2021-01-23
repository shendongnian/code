     private void RouteMissingEdges()
     {
         foreach (var edge in Graph.Edges)
         {
             if (edge.Curve == null)
             {
                 SmoothedPolyline ignore;
            
                 edge.Curve = edgeRouter_.RouteSplineFromPortToPortWhenTheWholeGraphIsReady(
                     new FloatingPort(edge.Source.BoundaryCurve, edge.Source.Center),
                     new FloatingPort(edge.Target.BoundaryCurve, edge.Target.Center),
                     true, out ignore);
                 Arrowheads.TrimSplineAndCalculateArrowheads(edge.EdgeGeometry,
                                                 edge.Source.BoundaryCurve,
                                                 edge.Target.BoundaryCurve,
                                                 edge.Curve, true,
                                                 false);
             }
         }
    }
