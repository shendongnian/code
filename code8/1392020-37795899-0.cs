    // get the JSON file content
    var josnData = File.ReadAllText(destinationFileName);
    
    // create NetTopology JSON reader
    var reader = new NetTopologySuite.IO.GeoJsonReader();
    // pass geoJson's FeatureCollection to read all the features
    var featureCollection = reader.Read<GeoJSON.Net.Feature.FeatureCollection>(josnData);
    // if feature collection is null then return 
    if (featureCollection == null)
    {
       return;
    }
    
    // loop through all the parsed featurd   
    for (int featureIndex = 0;
         featureIndex < featureCollection.Features.Count;
         featureIndex++)
    {
      // get json feature
      var jsonFeature = featureCollection.Features[featureIndex];
      Geometry geom = null;
       
       // get geometry type to create appropriate geometry
        switch (jsonFeature.Geometry.Type)
        {
          case GeoJSONObjectType.Point:
            break;
          case GeoJSONObjectType.MultiPoint:
            break;
          case GeoJSONObjectType.LineString:
            break;
          case GeoJSONObjectType.MultiLineString:
            break;
          case GeoJSONObjectType.Polygon:
          {
            var polygon = jsonFeature.Geometry as GeoJSON.Net.Geometry.Polygon;
            var coordinates = new List <Point3D>();
            foreach (var ring in polygon.Coordinates)
            {
              if (ring.IsLinearRing())
              {
                foreach (var coordinate in ring.Coordinates)
                {
                  var location = coordinate as GeographicPosition;
                  if (location == null)
                  {
                    continue;
                  }
                  coordinates.Add(new Point3D(location.Longitude,
                                              location.Latitude,
                                              location.Altitude.HasValue ? location.Altitude.Value : 0 ));
                }
              }
            }
            geom = new Polygon(new LinearRing(new CoordinateSequence(coordinates.ToArray())),
                               null);
          }
           break;
          case GeoJSONObjectType.MultiPolygon:
            break;
          case GeoJSONObjectType.GeometryCollection:
            break;
          case GeoJSONObjectType.Feature:
            break;
          case GeoJSONObjectType.FeatureCollection:
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
       }
