    using (var ctx = new YourContext())
    {
       ctx.PointEntities.AddRange(Points);       //see below
       ctx.GeometryEntites.AddRange(Geometries); // " "
       ctx.SaveChanges();
    }
