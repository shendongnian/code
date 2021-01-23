    //Steps to Converting GeoJSON response to FeatureCollection
    //1. Add NetTopologySuite.IO.GeoJson package from Nuget Package Manager.
    //2. Write Following Code Snap:
   
     string Filepath = "Your filepath here";
        var josnData = File.ReadAllText(Filepath);
                            var reader = new NetTopologySuite.IO.GeoJsonReader();
                            var featureCollection = 
          reader.Read<GeoJSON.Net.Feature.FeatureCollection>(josnData);
        
        //in my case i did it like this
         for (int fIndex = 0; fIndex < featureCollection.Features.Count; fIndex++)
                            {
                                var AreaDetails = 
         featureCollection.Features[fIndex].Properties;
                                for (int AIndex = 0; AIndex < AreaDetails.Count; 
         AIndex++)
                                {
                                    var element = AreaDetails.ElementAt(AIndex);
                                    var Key = element.Key;
                                    var Value = element.Value;
                                    if (Key == "GML_ID")
                                    {
                                        areaDetails.StateCode = Value.ToString();
                                    }
                                    else if (Key == "STNAME")
                                    {
                                        areaDetails.State = Value.ToString();
                                    }
                                    else if (Key == "DISTFULL")
                                    {
                                        areaDetails.DistrictCode = Value.ToString();
                                    }
                                    else if (Key == "DTNAME")
                                    {
                                        areaDetails.District = Value.ToString();
                                    }
                                    else if (Key == "IPCODE")
                                    {
                                        areaDetails.TalukaCode = Value.ToString();
                                    }
                                    else if (Key == "IPNAME")
                                    {
                                        areaDetails.Taluka = Value.ToString();
                                    }
                                    else if (Key == "VLGCD2001")
                                    {
                                        areaDetails.AreaCode = Value.ToString();
                                    }
                                    else if (Key == "VILLNAME")
                                    {
                                        areaDetails.AreaName = Value.ToString();
                                    }
                                }
                                var AreaCoords = featureCollection.Features[fIndex].Geometry;
                                var Type = AreaCoords.Type;
                                LocationDetails locationDetails = new LocationDetails();
        
                                if (Type == GeoJSONObjectType.Polygon)
                                {
                                    var polygon = AreaCoords as GeoJSON.Net.Geometry.Polygon;
                                    var polygonCoords = polygon.Coordinates[0].Coordinates;
        
                                    for (int AIndex = 0; AIndex < polygonCoords.Count; AIndex++)
                                    {
                                        locationDetails.lat = Convert.ToDecimal(polygonCoords[AIndex].Latitude);
                                        locationDetails.lng = Convert.ToDecimal(polygonCoords[AIndex].Longitude);
                                        locationDetailsList.Add(locationDetails);
                                    }
                                }
