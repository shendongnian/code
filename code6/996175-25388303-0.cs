    private IEnumerable<PathGeometry> FindAllPathGeometries(Geometry geometry)
    {
        var pathGeometry = geometry as PathGeometry;
        if (pathGeometry != null) {
            yield return pathGeometry;
        } else {
            var geoGroup = geometry as GeometryGroup;
            if (geoGroup != null) {
                foreach (var geo in geoGroup.Children) {
                    foreach (var pg in FindAllPathGeometries(geo)) {
                        yield return pg;
                    }
                }
            }
        }
    }
