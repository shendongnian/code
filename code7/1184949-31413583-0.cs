     (from a in context.DashboardTiles
     group a by new { a.CategoryID, a.ID, a.Name } into b 
     select new BusinessObjects.DashboardTileBO
            {
                ID = b.Key.ID,
                Name = b.Key.Name,
                DashboardTiles = b.ToList(),
            }).ToList();
