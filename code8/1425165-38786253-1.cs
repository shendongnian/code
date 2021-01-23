	var query = db.Restaurants.AsQueryable();
	if (!string.IsNullOrEmpty(Name))
		query = query.Where(c => c.Nom.Contains(Name));
	if (RegionId != Guid.Empty)
		query = query.Where(c => c.RegionId == RegionId);
	if (typeId != Guid.Empty)
		query = query.Where(tc=> tc.TypeCuisines.Any(r => r.TypeCuisineId == typeId));
	return query.ToList();
