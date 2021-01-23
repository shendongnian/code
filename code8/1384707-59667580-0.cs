    var x = 1530088.96d;
    var y = 5085240.83d;
    var epsg3857ProjectedCoordinateSystem = ProjNet.CoordinateSystems.ProjectedCoordinateSystem.WebMercator;
    var epsg4326GeographicCoordinateSystem = ProjNet.CoordinateSystems.GeographicCoordinateSystem.WGS84;
    var coordinateTransformationFactory = new ProjNet.CoordinateSystems.Transformations.CoordinateTransformationFactory();
    var coordinateTransformation = coordinateTransformationFactory.CreateFromCoordinateSystems(epsg3857ProjectedCoordinateSystem, epsg4326GeographicCoordinateSystem);
    var epsg3857Coordinate = new GeoAPI.Geometries.Coordinate(x, y);
    var epsg4326Coordinate = coordinateTransformation.MathTransform.Transform(epsg3857Coordinate);
