    modelBuilder.Entity<ConnectionPointRoute>()
        .HasKey(c => new { c.ConnectionPointId, c.RouteId });
    modelBuilder.Entity<ConnectionPoint>()
        .HasMany(c => c.ConnectionPointRoutes)
        .WithRequired(x => x.ConnectionPoint)
        .HasForeignKey(c => c.ConnectionPointId);
    modelBuilder.Entity<Route>()
        .HasMany(c => c.ConnectionPointRoutes)
        .WithRequired(x => x.Route)
        .HasForeignKey(c => c.RouteId);
