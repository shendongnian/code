    IEnumerable<PointEntity> Points =ProvidedGeometries
                        .SelectMany(g => g.Points);
     
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
