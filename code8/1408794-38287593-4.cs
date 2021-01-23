    var region = await db.Regions
        .Select(r =>
            new RegionVM
            {
                Region_ID = r.Region_ID,
                Region_Name = r.Region_Name
            }
        )
        .Where(r => region_id.Contains(r.Region_ID))
        .ToListAsync();
