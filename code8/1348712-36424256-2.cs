    public ActionResult GetCitiesWithBranches(int regionID)
        {
            var cities =
                _context.Cities.Where(e => e.RegionCode == regionID)
                    .Select(e => new { ID = e.CityCode, Name = e.Name })
                    .ToList();
            return Json(new { cities = cities });
        }
