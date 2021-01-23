    IEnumerable<PointEntity> Points = new PointEntity[] // just an example
            {
                new PointEntity() { GeometryId=1, X=1, Y=1, Id = 1},
                new PointEntity() { GeometryId=1, X=1, Y=2, Id = 2},
                new PointEntity() { GeometryId=1, X=2, Y=1, Id = 3},
                new PointEntity() { GeometryId=1, X=2, Y=2, Id = 4},
                new PointEntity() { GeometryId=2, X=1, Y=1, Id = 1},
                new PointEntity() { GeometryId=2, X=1, Y=2, Id = 2}
            };
    
    var geometries = Points.GroupBy(
        p => p.GeometryId,
        p => BitConverter.GetBytes(p.Id),
        (id, points) =>
        new GeometryEntity()
        {
            Id = id,
            Data = 
            BitConverter.GetBytes(points.Count()).Concat(
                points.Aggregate( (a,b) => a.Concat(b).ToArray() )
            ).ToArray()
        }
        );
