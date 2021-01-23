    public static bool PointCollectionsOverlap_Slow(PointCollection area1, PointCollection area2)
    {
        PathGeometry pathGeometry1 = GetPathGeometry(area1);
        PathGeometry pathGeometry2 = GetPathGeometry(area2);
        bool result = pathGeometry1.FillContainsWithDetail(pathGeometry2) != IntersectionDetail.Empty;
        return result;
    }
    
    public static PathGeometry GetPathGeometry(PointCollection polygonCorners)
    {
        List<PathSegment> pathSegments = new List<PathSegment> { new PolyLineSegment(polygonCorners, true) };
        PathGeometry pathGeometry = new PathGeometry();
        pathGeometry.Figures.Add(new PathFigure(polygonCorners[0], pathSegments, true));
        return pathGeometry;
    }
