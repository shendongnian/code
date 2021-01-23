    public static class SqlGeometryToShapeConverter
    {
        public static ShapefileConverter Create<T>(IEnumerable<T> items, 
                                                   Func<T, DbGeometry> geoFunc, 
                                                   Func<T, string> nameFunc) 
            where T : class
        {
            var converter = new ShapefileConverter();
            foreach (var item in items)
            {
                var rec = new ShapefileRecord();
                var points = new List<Point>();
                var geometry = geoFunc(item);
                Debug.Assert(geometry.PointCount != null, "geometry.PointCount != null");
                // Points are 1 based in DbGeometry
                var pointCount = geometry.PointCount;
                for (var pointIndex = 1; pointIndex <= pointCount; pointIndex++)
                {
                    var point = geometry.PointAt(pointIndex);
                    Debug.Assert(point.XCoordinate != null, "point.XCoordinate != null");
                    Debug.Assert(point.YCoordinate != null, "point.YCoordinate != null");
                    points.Add(new Point(point.XCoordinate.Value, point.YCoordinate.Value));
                }
                rec.Fields = new ShapefileRecordFields { { "Name", nameFunc(item) } };
                rec.Points = new List<List<Point>> { points };
                converter.Add(rec);
            }
            return converter;
        }
    }
