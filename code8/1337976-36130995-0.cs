    var graphicsToReturn = new List<Graphic>();
    var geometryService = new GeometryService();
    geometryService.InitializeWithLocalService();
    foreach (var currentGraphic in layer.Graphics)
    {
        var intersectSection = geometryService.Intersect(new List<Graphic> { currentGraphic }, polygonGeometry);
        if (intersectSection != null)
        {
            foreach (var intersectionGraphic in intersectSection)
            {
                  if (intersectionGraphic != null )
                  {
                      var polygon = intersectionGraphic.Geometry as Polygon;
                      var point = intersectionGraphic.Geometry as MapPoint;
                      var line = intersectionGraphic.Geometry as Polyline;
                      if (polygon != null && polygon.Rings.Count > 0)
                      {
                         graphicsToReturn.Add(currentGraphic);
                      }
                      else if (point != null && !double.IsNaN(point.X) && !double.IsNaN(point.Y))
                      {                                     
                         graphicsToReturn.Add(currentGraphic);
                      }
                      else if (line != null && line.Paths.Count > 0)
                      {
                         graphicsToReturn.Add(currentGraphic);
                      }
                   }
              }
          }
     }
