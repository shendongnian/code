    IEnumerable<Geometry> ProvidedGeometries =
        new Geometry[]
        {
            new Geometry()
            {
                Points = new PointEntity[]
        {
            new PointEntity() { GeometryId=1, X=1, Y=1, Id = 1},
            new PointEntity() { GeometryId=1, X=1, Y=2, Id = 2},
            new PointEntity() { GeometryId=1, X=2, Y=1, Id = 3},
            new PointEntity() { GeometryId=1, X=2, Y=2, Id = 4}
        }
            },
        new Geometry()
            {
                Points = new PointEntity[]
        {
            new PointEntity() { GeometryId=2, X=1, Y=1, Id = 1},
            new PointEntity() { GeometryId=2, X=1, Y=2, Id = 2}
        }
            }
        };
