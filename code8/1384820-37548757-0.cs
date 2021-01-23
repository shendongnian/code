        public IEnumerable<Route> GetAll(int locationId)
        {
            return _db.Routes
                .Include(o => o.ConnectionPointRoutes.Select(s => s.Segment))
                .Include(o => o.ConnectionPointRoutes.Select(c => c.ConnectionPoint))
                .Where(c => c.ConnectionPointRoutes.Select(s => s.ConnectionPoint.Location)
                .FirstOrDefault(q => q.LocationId == locationId).LocationId == locationId)
                .ToList();
        }
